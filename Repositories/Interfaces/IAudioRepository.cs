using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;

namespace AudioSummarizer.Repositories.Interfaces
{
    public interface IAudioRepository
    {
        // Adds a new audio
        Task<AudioModel> Add(AudioModel Audio);

        // Return the list of all audio summaries
        Task<List<AudioModel>> List();

        // Return a specific audio summary
        Task<AudioModel?> Details(long AudioId);
    }
}
