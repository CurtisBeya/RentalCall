using System.ComponentModel.DataAnnotations;

namespace RentalCall.Models
{
    public class CallCategoryModel: BaseModel
    {
        //public CallCategory() { }
        [Required]
        public String Name { get; set; }
    }
}
