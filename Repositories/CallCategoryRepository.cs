using AudioSummarizer.Models;
using AudioSummarizer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AudioSummarizer.Repositories
{
    public class CallCategoryRepository: ICallCategoryRepository
    {
        private readonly AudioSummarizerDbContext _audioSummarizerDbContext;
        private readonly ILogger<CallCategoryRepository> _logger;

        public CallCategoryRepository(AudioSummarizerDbContext audioSummarizerDbContext, ILogger<CallCategoryRepository> logger)
        {
            _audioSummarizerDbContext = audioSummarizerDbContext;
            _logger = logger;
        }

        // Adds a new call category
        public async Task<CallCategoryModel> Add(CallCategoryModel CallCategory)
        {
            try
            {
                _audioSummarizerDbContext.CallCategories.Add(CallCategory);
                await _audioSummarizerDbContext.SaveChangesAsync();
                return CallCategory;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while adding an audio: {CallCategory.Name}", CallCategory);
                throw new DbUpdateException($"Unable to add to the database");
            }

        }

        // Return the list of all call categories
        public async Task<List<CallCategoryModel>> List()
        {
            try
            {
                return await _audioSummarizerDbContext.CallCategories.ToListAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an call category list");
                throw new KeyNotFoundException($"Unable to return the list");
            }
        }

        // Return a specific call category details
        public async Task<CallCategoryModel?> Details(long CallCategoryId)
        {
            try
            {
                return await _audioSummarizerDbContext.CallCategories.FindAsync(CallCategoryId);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a call category with the ID: {CallCategoryId}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }
    }
}
