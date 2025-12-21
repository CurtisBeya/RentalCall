using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models.Dtos
{
    public class ActionItemUpdateModelDto: BaseUpdateModelDto
    {
        [Required]
        public bool AssignedToDepartment { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public DateTime CompletedDateTime { get; set; }
    }
}
