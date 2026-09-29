using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models.Dtos
{
    public class BaseUpdateModelDto
    {
        [Required]

        public long Id { get; set; }
    }
}
