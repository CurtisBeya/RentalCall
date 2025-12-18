using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;

namespace AudioSummarizer.Repositories.Interfaces
{
    public interface IAudioRepository
    {
        // Adds a new audio
        public Task<AudioModel> Add(AudioModel Audio);

        // Return the list of all audio summaries
        public Task<List<AudioModel>> List();

        // Return a specific audio summary
        public Task<AudioModel?> Details(long AudioId);
    }
}
