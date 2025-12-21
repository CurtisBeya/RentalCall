using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;

namespace AudioSummarizer.Repositories.Interfaces
{
    public interface ICallRepository
    {
        // Adds a new audio
        Task<CallModel> Add(CallModel Call);

        //Updates an existing call
        Task<CallModel> Update(CallModel Call);

        // Return the list of all audio summaries
        Task<List<CallModel>> List();

        Task<List<CallModel>> ListGivenCategoryId(long CategoryId);
     
        // Return a specific audio summary
        Task<CallModel?> Details(long callId);

        //Return a specific call details given the audio file name
        Task<CallModel?> SearchGivenAudioFileName(String AudioFileName);
    }
}
