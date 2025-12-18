using AudioSummarizer.Models;

namespace AudioSummarizer.Repositories.Interfaces
{
    public interface IActionItemRepository
    {
        // Adds a new audio
        public Task<ActionItemModel> Add(ActionItemModel ItemAction);

        // Updates a new audio
        public Task<ActionItemModel> Update(ActionItemModel ItemAction);

        // Return the list of all action items
        public Task<List<ActionItemModel>> List();

        // Return a specific item action summary
        public Task<ActionItemModel?> Details(long ActionItemId);
    }
}
