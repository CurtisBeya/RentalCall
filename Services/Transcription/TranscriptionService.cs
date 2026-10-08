using RentalCall.Services.Transcription.Models;
using System.Net.Http.Json;

namespace RentalCall.Services.Transcription
{
    public class TranscriptionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public TranscriptionService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AzureSpeech");
        }

        public async Task<TranscriptionResult> TranscribeCall(Uri sasUri)
        {
            // 1. Submit transcription job
            var requestBody = new
            {
                contentUrls = new[]
                {
                    sasUri.ToString()
                },

                locale = "en-US",

                displayName = "RentalCall Transcription",

                properties = new
                {
                    diarizationEnabled = false,

                    channels = new[]
                    {
                        new { channelNumber = 0 },
                        new { channelNumber = 1 }
                    }
                }
            };

            var response = await _httpClient.PostAsJsonAsync(
                $"{_endpoint}/speechtotext/v3.1/transcriptions",
                requestBody);

            response.EnsureSuccessStatusCode();

            var job = await response.Content
                .ReadFromJsonAsync<JobResponse>();

            if (job == null || string.IsNullOrWhiteSpace(job.Self))
            {
                throw new InvalidOperationException(
                    "Azure Speech did not return a valid transcription job.");
            }

            // 2. Poll until transcription is complete
            while (job.Status == "NotStarted" ||
                   job.Status == "Running")
            {
                await Task.Delay(TimeSpan.FromSeconds(5));

                var pollResponse = await _httpClient.GetAsync(job.Self);

                pollResponse.EnsureSuccessStatusCode();

                job = await pollResponse.Content
                    .ReadFromJsonAsync<JobResponse>();

                if (job == null)
                {
                    throw new InvalidOperationException(
                        "Unable to retrieve the transcription job status.");
                }
            }

            // 3. Check whether transcription succeeded
            if (job.Status != "Succeeded")
            {
                throw new InvalidOperationException(
                    $"Transcription failed with status: {job.Status}");
            }

            // 4. Get the transcription files
            var filesResponse = await _httpClient.GetAsync(
                $"{job.Self}/files");

            filesResponse.EnsureSuccessStatusCode();

            var files = await filesResponse.Content
                .ReadFromJsonAsync<FileListResponse>();

            if (files?.Values == null || files.Values.Count == 0)
            {
                throw new InvalidOperationException(
                    "No transcription files were returned.");
            }

            // 5. Find the transcription file
            var transcriptFile = files.Values
                .FirstOrDefault(file =>
                    file.Kind == "Transcription");

            if (transcriptFile == null ||
                string.IsNullOrWhiteSpace(
                    transcriptFile.Links?.ContentUrl))
            {
                throw new InvalidOperationException(
                    "The transcription result could not be found.");
            }

            // 6. Download the transcription JSON
            var transcriptResponse = await _httpClient.GetAsync(
                transcriptFile.Links.ContentUrl);

            transcriptResponse.EnsureSuccessStatusCode();

            var transcription =
                await transcriptResponse.Content
                    .ReadFromJsonAsync<AzureTranscriptionResponse>();

            if (transcription == null ||
                transcription.RecognizedPhrases == null)
            {
                throw new InvalidOperationException(
                    "The transcription response was empty.");
            }

            // 7. Extract spoken text, channel and confidence
            var phrases = transcription.RecognizedPhrases
                .Where(phrase =>
                    phrase.NBest != null &&
                    phrase.NBest.Count > 0)
                .Select(phrase =>
                {
                    var bestResult = phrase.NBest[0];

                    var speaker = phrase.Channel switch
                    {
                        0 => "Agent",
                        1 => "Customer",
                        _ => $"Channel {phrase.Channel}"
                    };

                    return new
                    {
                        Speaker = speaker,
                        Text = bestResult.Display,
                        Confidence = bestResult.Confidence
                    };
                })
                .Where(phrase =>
                    !string.IsNullOrWhiteSpace(phrase.Text))
                .ToList();

            // 8. Build clean transcript
            var transcript = string.Join(
                Environment.NewLine + Environment.NewLine,
                phrases.Select(phrase =>
                    $"{phrase.Speaker}: {phrase.Text}"));

            // 9. Calculate average confidence
            var confidence = phrases.Count > 0
                ? phrases.Average(phrase => phrase.Confidence)
                : 0;

            // 10. Return only transcript and confidence
            return new TranscriptionResult
            {
                Transcript = transcript,
                Confidence = confidence
            };
        }
    }
}