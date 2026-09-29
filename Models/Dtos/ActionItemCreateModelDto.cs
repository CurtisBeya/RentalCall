using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models.Dtos
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
