using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;

namespace AudioSummarizer.Managers.Interfaces
{
    public interface IAudioManager
    {
        // Adds a new audio
        Task<AudioModel> Add(AudioModelDto AudioDto);

        // Return the list of all audio summaries
        Task<List<AudioModel>> List();

        // Return a specific audio summary
        Task<AudioModel?> Details(long AudioId);
    }
}
