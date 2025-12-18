using AudioSummarizer.Models;
using AudioSummarizer.Repositories.Interfaces;

namespace AudioSummarizer.Repositories
{
    public class ActionItemRepository: IActionItemRepository
    {
        // Adds a new action item
        public Task<ActionItemModel> Add(ActionItemModel ActionItem)
        {
            return Task.FromResult(new ActionItemModel());

        }

        // Updates a new action item
        public Task<ActionItemModel> Update(ActionItemModel ActionItem)
        {
            return Task.FromResult(new ActionItemModel());

        }

        // Return the list of all action items
        public Task<List<ActionItemModel>> List()
        {
            return Task.FromResult(new List<ActionItemModel>());
        }

        // Return a specific action item summary
        public Task<ActionItemModel?> Details(long ActionItemId)
        {
            return Task.FromResult<ActionItemModel?>(null);
        }
    }
}
