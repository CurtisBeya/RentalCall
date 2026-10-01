using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models
{
    public class UserRoleModel: BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}
