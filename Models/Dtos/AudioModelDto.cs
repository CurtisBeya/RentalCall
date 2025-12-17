using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models.Dtos
{
    public class AudioModelDto
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public FormFile AudioFile { get; set; }
    }
}

