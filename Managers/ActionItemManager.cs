using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using RentalCall.Models.Dtos;
using RentalCall.Repositories;
using RentalCall.Repositories.Interfaces;
using AutoMapper;
using System.ComponentModel.Design;

namespace RentalCall.Managers
{
    public class ActionItemManager: IActionItemManager
    {
        private readonly IActionItemRepository _actionItemRepository;
        private readonly IMapper _mapper;
        public ActionItemManager(IActionItemRepository actionItemRepositury, IMapper mapper)
        {
            _actionItemRepository = actionItemRepositury;
            _mapper = mapper;
        }

        //adds an action item
        public async Task<ActionItemModel> SystemAdd(String Description, long CallId)
        {
            ActionItemModel ActionItem= new ActionItemModel();

            ActionItem.Description = Description;
            ActionItem.CallId = CallId;
            ActionItem.AssignedToDepartment = false;
            ActionItem.IsCompleted = false;
            ActionItem.CreatedDateTime = DateTime.Now;

            return await _actionItemRepository.Add(ActionItem);
        }

        public async Task<ActionItemModel> ManualAdd(ActionItemCreateModelDto ActionItemDto)
        {
            ActionItemModel ActionItem = _mapper.Map<ActionItemModel>(ActionItemDto);

            ActionItem.Description = ActionItem.Description;
            ActionItem.CallId = ActionItem.CallId;
            ActionItem.AssignedToDepartment = ActionItemDto.AssignedToDepartment;
            ActionItem.IsCompleted = false;
            ActionItem.CreatedDateTime = DateTime.Now;

            return await _actionItemRepository.Add(ActionItem);
        }

        //Updates an action item
        public async Task<ActionItemModel> Update(ActionItemUpdateModelDto ActionItemDto)
        {
            //Request existing model
            ActionItemModel? ActionItem = await Details(ActionItemDto.Id);

            //Update the model

            if(!ActionItem.IsCompleted)
            {
                ActionItem.AssignedToDepartment = ActionItemDto.AssignedToDepartment;
                
                if (ActionItem.AssignedToDepartment)
                {
                    //IsCompleted is updated only when assigned is true
                    ActionItem.IsCompleted = ActionItemDto.IsCompleted;
                    ActionItem.CompletedDateTime = DateTime.Now;
                }
                else
                    ActionItem.IsCompleted = false;

                ActionItem.UpdatedDateTime = DateTime.Now;

            }
            else
                throw new ArgumentException($"Error: ActionItem already completed, update not allowed");

            return await _actionItemRepository.Update(ActionItem);
        }

        // Return the list of all action items
        public async Task<List<ActionItemModel>> List()
        {
            return await _actionItemRepository.List();
        }

        // Return the list of action items given the call Id
        public async Task<List<ActionItemModel>> ListGivenCallId(long CallId)
        {
            return await _actionItemRepository.ListGivenCallId(CallId);
        }

        // Return a specific Action Item summary
        public async Task<ActionItemModel?> Details(long ActionItemId)
        {
            return await _actionItemRepository.Details(ActionItemId);
        }
    }
}
