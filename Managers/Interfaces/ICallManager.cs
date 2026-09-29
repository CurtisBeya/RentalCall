using RentalCall.Models;
using RentalCall.Models.Dtos;

namespace RentalCall.Managers.Interfaces
{
    public interface ICallManager
    {
        // Adds a new call
        Task<CallModel> Add(CallCreateModelDto CallDto);

        //Updates an existing call
        Task<CallModel> Update(CallUpdateModelDto CallDto);

        //Automatic call update by the system
        Task<CallModel> CallReviewSystemUpdate(long CallId);

        // Return the list of all call summaries
        Task<List<CallModel>> List();

        // Return the list of all call given category 
        Task<List<CallModel>> ListGivenCategoryName(String CategoryName);

        // Return a specific audio summary
        Task<CallModel?> Details(long CallId);

        //Return a specific call details given the audio file name
        Task<CallModel?> SearchGivenAudioFileName(String AudioFileName);
    }
}
