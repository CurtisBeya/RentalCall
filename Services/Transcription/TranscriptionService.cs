using RentalCall.Services.Transcription.Models;
using System.Net.Http;

namespace RentalCall.Services.Transcription
{
    public class TranscriptionService
    {
        private readonly HttpClient _httpClient;
        TranscriptionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }      

        public async Task<string> TranscribeCall(Uri sasUri)
        {
            // Build request body
            var requestBody = new
            {
                contentUrls = new[] { sasUri.ToString() },
                locale = "en-US",
                displayName = "Transcription job",
                properties = new
                {
                    diarizationEnabled = false,
                    channels = new [] // sets multi-channel audio processing to differentiate in transcripts speakers, if applicable
                    {
                        new { channelNumber = 0 },
                        new { channelNumber = 1 }
                    }                                           
                }
            };

            // Submit to Speech-to-Text API
            var response = await _httpClient.PostAsJsonAsync(
                "https://<region>.api.cognitive.microsoft.com/speechtotext/v3.1/transcriptions",
                requestBody);

            response.EnsureSuccessStatusCode();

            // Parse initial job response
            var job = await response.Content.ReadFromJsonAsync<JobResponse>();

            // Poll until status = Succeeded
            string jobUrl = job.Self;
            string status = job.Status;

            while (status == "NotStarted" || status == "Running")
            {
                await Task.Delay(5000); // wait 5 seconds before polling again

                var pollResponse = await _httpClient.GetAsync(jobUrl);
                pollResponse.EnsureSuccessStatusCode();

                job = await pollResponse.Content.ReadFromJsonAsync<JobResponse>();
                status = job.Status;
            }

            // Once succeeded, fetch final result
            if (status == "Succeeded")
            {
                var resultResponse = await _httpClient.GetAsync(jobUrl + "/files");
                resultResponse.EnsureSuccessStatusCode();

                var files = await resultResponse.Content.ReadFromJsonAsync<FileListResponse>();

                // The transcript file is usually in "results.json"
                var transcriptFile = files.Values.FirstOrDefault(f => f.Kind == "Transcription");
                if (transcriptFile != null)
                {
                    var transcriptResponse = await _httpClient.GetAsync(transcriptFile.Links.ContentUrl);
                    transcriptResponse.EnsureSuccessStatusCode();

                    return await transcriptResponse.Content.ReadAsStringAsync();
                }
            }

            return "";
        }
    }
}
