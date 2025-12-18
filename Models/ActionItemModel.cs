using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models
{
    public class ActionItemModel: BaseModel
    {
        [Required]
        public String Description { get; set; }

        [Required]
        public long AudioId { get; set; }

        public String? AssignedTo { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [JsonIgnore]
        public AudioModel Audio { get; set; }
    }
}
