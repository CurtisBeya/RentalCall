using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;

namespace AudioSummarizer.Managers.Interfaces
{
    public interface IActionItemManager
    {

        // add an item action
        Task<ActionItemModel> Add(ActionItemModelDto ActionItemDto);

        // updates an item action
        Task<ActionItemModel> Update(ActionItemModelDto ActionItemDto);

        // Return the list of all action items
        Task<List<ActionItemModel>> List();

        // Return a specific Action Item summary
        Task<ActionItemModel?> Details(long ActionItemId);
    }
}
