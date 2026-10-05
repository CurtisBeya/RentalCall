using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models.Dtos
{
    public class LoginDetailsDto
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
