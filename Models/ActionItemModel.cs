using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models
{
    public class ActionItemModel: BaseModel
    {
        [Required]
        public String Description { get; set; }

        [Required]
        public long CallId { get; set; }

        [Required]
        public bool AssignedToDepartment { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        public DateTime? CompletedDateTime { get; set; }

        [JsonIgnore]
        public CallModel Call { get; set; }
    }
}
