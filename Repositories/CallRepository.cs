using AudioSummarizer;
using AudioSummarizer.Models;
using AudioSummarizer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AudioSummarizer.Repositories
{
    public class CallRepository: ICallRepository
    {
        private readonly AudioSummarizerDbContext _audioSummarizerDbContext;
        private readonly ILogger<CallRepository> _logger;

        public CallRepository(AudioSummarizerDbContext audioSummarizerDbContext, ILogger<CallRepository> logger)
        {
            _audioSummarizerDbContext = audioSummarizerDbContext;
            _logger = logger;
        }

        // Adds a new call
        public async Task<CallModel> Add(CallModel Call)
        {
            try
            {
                _audioSummarizerDbContext.Calls.Add(Call);
                await _audioSummarizerDbContext.SaveChangesAsync();
                return Call;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while adding an audio: {Call.AudioFileName}", Call);
                throw new DbUpdateException($"Unable to add to the database");
            }

        }

        // Return the list of all calls summaries
        public async Task<List<CallModel>> List()
        {
            try
            {
                return await _audioSummarizerDbContext.Calls.ToListAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an audio list");
                throw new KeyNotFoundException($"Unable to return the list");
            }
        }

        // Return a specific call summary details
        public async Task<CallModel?> Details(long CallId)
        {
            try
            {
                return await _audioSummarizerDbContext.Calls.FindAsync(CallId);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a call with the ID: {CallId}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }
    }
}
