using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models
{
    public class AudioModel: BaseModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public FormFile AudioFile { get; set; }

        [Required]
        public String Topic { get; set; }

        [Required]
        public String Summary { get; set; }

        [Required]
        public float Confindence {  get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
