using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models.Dtos
{
    public class CallModelDto
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public FormFile AudioFile { get; set; }
    }
}

