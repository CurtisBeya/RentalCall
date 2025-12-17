using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models.Dtos
{
    public class AudioModelDto
    {
        [Required]
        String Name { get; set; }

        [Required]
        FormFile AudioFile { get; set; }
    }
}

