using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models.Dtos
{
    public class BaseUpdateModelDto
    {
        [Required]

        public long Id { get; set; }
    }
}
