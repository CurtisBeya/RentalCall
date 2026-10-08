namespace RentalCall.Services.Transcription.Models
{
    public class TranscriptionResult
    {
        public string Transcript { get; set; } = string.Empty;
        public double Confidence { get; set; }
    }
}
