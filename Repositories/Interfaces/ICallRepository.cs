using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;

namespace AudioSummarizer.Repositories.Interfaces
{
    public interface ICallRepository
    {
        // Adds a new audio
        Task<CallModel> Add(CallModel Call);

        // Return the list of all audio summaries
        Task<List<CallModel>> List();

        // Return a specific audio summary
        Task<CallModel?> Details(long callId);
    }
}
