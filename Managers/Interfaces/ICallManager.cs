using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;

namespace AudioSummarizer.Managers.Interfaces
{
    public interface ICallManager
    {
        // Adds a new call
        Task<CallModel> Add(CallCreateModelDto CallDto);

        Task<CallModel> Update(CallUpdateModelDto CallDto);

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
