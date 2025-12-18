using AudioSummarizer;
using AudioSummarizer.Models;
using AudioSummarizer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AudioSummarizer.Repositories
{
    public class ActionItemRepository: IActionItemRepository
    {
        private readonly AudioSummarizerDbContext _audioSummarizerDbContext;
        private readonly ILogger<ActionItemRepository> _logger;

        public ActionItemRepository(AudioSummarizerDbContext audioSummarizerDbContext, ILogger<ActionItemRepository> logger)
        {
            _audioSummarizerDbContext = audioSummarizerDbContext;
            _logger = logger;
        }
        // Adds a new action item
        public async Task<ActionItemModel> Add(ActionItemModel ActionItem)
        {
            try
            {
                _audioSummarizerDbContext.ActionItems.Add(ActionItem);
                await _audioSummarizerDbContext.SaveChangesAsync();
                return ActionItem;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while adding an action item: {ActionItem.Description}", ActionItem);
                throw new DbUpdateException($"Unable to add to the database");
            }

        }

        // Updates a new action item
        public async Task<ActionItemModel> Update(ActionItemModel ActionItem)
        {
            try
            {
                _audioSummarizerDbContext.ActionItems.Update(ActionItem);
                await _audioSummarizerDbContext.SaveChangesAsync();
                return ActionItem;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while updating an action item: {ActionItem.Description}", ActionItem);
                throw new DbUpdateException($"Unable to add to the database");
            }

        }

        // Return the list of all action items
        public async Task<List<ActionItemModel>> List()
        {
            try
            {
                return await _audioSummarizerDbContext.ActionItems.ToListAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an action item list");
                throw new KeyNotFoundException($"Unable to return the list");
            }
        }

        // Return a specific action item summary
        public async Task<ActionItemModel?> Details(long ActionItemId)
        {
            try
            {
                return await _audioSummarizerDbContext.ActionItems.FindAsync(ActionItemId);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an action item with the ID: {ActionItemId}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }
    }
}
