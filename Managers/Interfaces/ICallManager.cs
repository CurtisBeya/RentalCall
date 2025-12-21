using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;

namespace AudioSummarizer.Managers.Interfaces
{
    public interface ICallManager
    {
        // Adds a new audio
        Task<CallModel> Add(CallCreateModelDto CallDto);

        Task<CallModel> Update(CallUpdateModelDto CallDto);

        // Return the list of all audio summaries
        Task<List<CallModel>> List();

        // Return a specific audio summary
        Task<CallModel?> Details(long CallId);
    }
}
