using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models.Dtos
{
    public class ActionItemModelDto
    {
        [Required]
        public String AssignedTo { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}
