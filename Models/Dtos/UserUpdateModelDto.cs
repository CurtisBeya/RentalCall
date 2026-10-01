using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models.Dtos
{
    public class UserUpdateModelDto: BaseUpdateModelDto
    {
        [Required]
        public long UserRoleId { get; set; }
    }
}
