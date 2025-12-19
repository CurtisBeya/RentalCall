using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AudioSummarizer.Models
{
    public class CallModel: BaseModel
    {
        [Required]
        public String AudioFileName { get; set; }

        [Required]
        public String AudioFilePath { get; set; }

        [Required]
        public String Summary { get; set; }

        [Required]
        public long CallCategoryId { get; set; }

        [Required]
        public Double CallCategoryConfidence { get; set; }

        [JsonIgnore]
        public CallCategoryModel Category { get; set; }

    }
}
