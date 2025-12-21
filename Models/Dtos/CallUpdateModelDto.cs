using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models.Dtos
{
    public class CallUpdateModelDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public bool HasBeenReviewed { get; set; }
    }
}
