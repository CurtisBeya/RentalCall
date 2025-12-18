using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models
{
    public class AudioModel: BaseModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public IFormFile AudioFile { get; set; }

        [Required]
        public String Topic { get; set; }

        [Required]
        public String Summary { get; set; }

    }
}
