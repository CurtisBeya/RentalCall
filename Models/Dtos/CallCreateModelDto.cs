using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models.Dtos
{
    public class CallCreateModelDto
    {
        [Required]
        public String AudioFileName { get; set; }

        [Required]
        public FormFile AudioFile { get; set; }
    }
}

