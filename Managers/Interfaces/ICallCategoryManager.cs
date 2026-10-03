using RentalCall.Models;

namespace RentalCall.Managers.Interfaces
{
    public interface ICallCategoryManager
    {
        //return the list of all call categories
        Task<List<CallCategoryModel>> List();
    }
}
