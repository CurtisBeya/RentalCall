using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models.Dtos
{
    public class UserCreateModelDto
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
    }
}
