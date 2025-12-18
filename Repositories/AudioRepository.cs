using AudioSummarizer;
using AudioSummarizer.Models;
using AudioSummarizer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AudioSummarizer.Repositories
{
    public class AudioRepository: IAudioRepository
    {
        private readonly AudioSummarizerDbContext _audioSummarizerDbContext;
        private readonly ILogger<AudioRepository> _logger;

        public AudioRepository(AudioSummarizerDbContext audioSummarizerDbContext, ILogger<AudioRepository> logger)
        {
            _audioSummarizerDbContext = audioSummarizerDbContext;
            _logger = logger;
        }

        // Adds a new audio
        public async Task<AudioModel> Add(AudioModel Audio)
        {
            try
            {
                _audioSummarizerDbContext.Audios.Add(Audio);
                await _audioSummarizerDbContext.SaveChangesAsync();
                return Audio;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while adding an audio: {Audio.Name}", Audio);
                throw new DbUpdateException($"Unable to add to the database");
            }

        }

        // Return the list of all audio summaries
        public async Task<List<AudioModel>> List()
        {
            try
            {
                return await _audioSummarizerDbContext.Audios.ToListAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an audio list");
                throw new KeyNotFoundException($"Unable to return the list");
            }
        }

        // Return a specific audio summary details
        public async Task<AudioModel?> Details(long AudioId)
        {
            try
            {
                return await _audioSummarizerDbContext.Audios.FindAsync(AudioId);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an audio with the ID: {AudioId}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }
    }
}
