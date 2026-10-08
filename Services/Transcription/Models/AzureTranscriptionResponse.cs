namespace RentalCall.Services.Transcription.Models
{
    public class AzureTranscriptionResponse
    {
        public List<RecognizedPhrase> RecognizedPhrases { get; set; } = new();
    }
}
