using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models.Dtos
{
    public class ActionItemCreateModelDto
    {
        [Required]
        public String Description { get; set; }

        [Required]
        public long CallId { get; set; }

        [Required]
        public bool AssignedToDepartment { get; set; }
    }
}
