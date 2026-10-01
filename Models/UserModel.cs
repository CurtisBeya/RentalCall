using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RentalCall.Models
{
    public class UserModel: BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public long UserRoleId { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public UserRoleModel UserRole { get; set; }
    }
}
