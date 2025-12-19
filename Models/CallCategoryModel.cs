using System.ComponentModel.DataAnnotations;

namespace AudioSummarizer.Models
{
    public class CallCategoryModel: BaseModel
    {
        //public CallCategory() { }
        [Required]
        public String Name { get; set; }
    }
}
