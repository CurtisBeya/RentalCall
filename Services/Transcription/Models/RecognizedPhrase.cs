namespace RentalCall.Services.Transcription.Models
{
    public class RecognizedPhrase
    {
        public int Channel { get; set; }
        public List<NBestResult> NBest { get; set; } = new();
    }

}
