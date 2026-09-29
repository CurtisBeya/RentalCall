using RentalCall.Models;
using RentalCall.Models.Dtos;

namespace RentalCall.Managers.Interfaces
{
    public interface IActionItemManager
    {

        // add an item action automatically by the system
        Task<ActionItemModel> SystemAdd(String Description, long CallId);

        Task<ActionItemModel> ManualAdd(ActionItemCreateModelDto ActionItemDto);

        // updates an item action
        Task<ActionItemModel> Update(ActionItemUpdateModelDto ActionItemDto);

        // Return the list of all action items
        Task<List<ActionItemModel>> List();

        //Return the list of action items given the call Id
        Task<List<ActionItemModel>> ListGivenCallId(long CallId);

        // Return a specific Action Item summary
        Task<ActionItemModel?> Details(long ActionItemId);
    }
}
