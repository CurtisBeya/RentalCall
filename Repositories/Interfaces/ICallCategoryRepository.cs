using RentalCall.Models;

namespace RentalCall.Repositories.Interfaces
{
    public interface ICallCategoryRepository
    {
        // Adds a new call category
        Task<CallCategoryModel> Add(CallCategoryModel CallCategory);

        // Return the list of all call categories
        Task<List<CallCategoryModel>> List();

        // Return a specific call category details
        Task<CallCategoryModel?> Details(long callCategoryId);

        Task<CallCategoryModel?> DetailsGivenCallCategoryName(String CallCategoryName);
    }
}
