using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models.Dtos
{
    public class CallUpdateModelDto: BaseUpdateModelDto
    {
        [Required]
        public bool HasBeenReviewed { get; set; }
    }
}
