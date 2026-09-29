using RentalCall;
using RentalCall.Models;
using RentalCall.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentalCall.Repositories
{
    public class ActionItemRepository: IActionItemRepository
    {
        private readonly RentalCallDbContext _RentalCallDbContext;
        private readonly ILogger<ActionItemRepository> _logger;

        public ActionItemRepository(RentalCallDbContext RentalCallDbContext, ILogger<ActionItemRepository> logger)
        {
            _RentalCallDbContext = RentalCallDbContext;
            _logger = logger;
        }
        // Adds a new action item
        public async Task<ActionItemModel> Add(ActionItemModel ActionItem)
        {
            try
            {
                _RentalCallDbContext.ActionItems.Add(ActionItem);
                await _RentalCallDbContext.SaveChangesAsync();
                return ActionItem;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while adding an action item with call Id: {ActionItem.CallId}", ActionItem);
                throw new DbUpdateException($"Unable to add to the database");
            }

        }

        // Updates a new action item
        public async Task<ActionItemModel> Update(ActionItemModel ActionItem)
        {
            try
            {
                _RentalCallDbContext.ActionItems.Update(ActionItem);
                await _RentalCallDbContext.SaveChangesAsync();
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
                return await _RentalCallDbContext.ActionItems.ToListAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an action item list");
                throw new KeyNotFoundException($"Unable to return the list");
            }
        }

        // Return the list of action items given CallId
        public async Task<List<ActionItemModel>> ListGivenCallId(long CallId)
        {
            try
            {
                return await _RentalCallDbContext.ActionItems
                    .Where(x => x.CallId == CallId)
                    .ToListAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an action item list given the call Id");
                throw new KeyNotFoundException($"Unable to return the list");
            }
        }

        // Return a specific action item
        public async Task<ActionItemModel?> Details(long ActionItemId)
        {
            try
            {
                return await _RentalCallDbContext.ActionItems.FindAsync(ActionItemId);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving an action item with the ID: {ActionItemId}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }
    }
}
