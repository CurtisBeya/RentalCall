using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models.Dtos
{
    public class ActionItemUpdateModelDto: BaseUpdateModelDto
    {
        [Required]
        public bool AssignedToDepartment { get; set; }

        public bool IsCompleted { get; set; }
    }
}
