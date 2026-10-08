namespace RentalCall.Services.Transcription.Models
{
    public class TranscriptionFile
    {
        public string Kind { get; set; } = string.Empty;
        public TranscriptionFileLinks Links { get; set; } = new();
    }
}
