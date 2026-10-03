using RentalCall.Models;

namespace RentalCall.Repositories.Interfaces
{
    public interface ICallCategoryRepository
    {
        // Return the list of all call categories
        Task<List<CallCategoryModel>> List();

        // Return a specific call category details
        Task<CallCategoryModel?> Details(long callCategoryId);

        Task<CallCategoryModel?> DetailsGivenCallCategoryName(String CallCategoryName);
    }
}
