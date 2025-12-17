using AudioSummarizer.Models;
using AudioSummarizer.Repositories.Interfaces;

namespace AudioSummarizer.Repositories
{
    public class AudioRepository: IAudioRepository
    {
        // Adds a new audio
        public Task<AudioModel> Add(AudioModel Audio)
        {
            return Task.FromResult(new AudioModel());

        }


        // Return the list of all audio summaries
        public Task<List<AudioModel>> List()
        {
            return Task.FromResult(new List<AudioModel>());
        }

        // Return a specific audio summary
        public Task<AudioModel?> Details(long AudioId)
        {
            return Task.FromResult<AudioModel?>(null);
        }
    }
}
