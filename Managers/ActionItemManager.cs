using AudioSummarizer.Managers.Interfaces;
using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;
using AudioSummarizer.Repositories;
using AudioSummarizer.Repositories.Interfaces;
using AutoMapper;

namespace AudioSummarizer.Managers
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
            ActionItem.AssignedToDepartment = ActionItemDto.AssignedToDepartment;
            ActionItem.UpdatedDateTime = DateTime.Now;

            if(ActionItem.AssignedToDepartment)
            {
                //IsCompleted is updated only when assigned is true
                ActionItem.IsCompleted = ActionItemDto.IsCompleted;

                //CompletedDateTime is updated only when assigned and IsCompleted are both true
                if (ActionItem.IsCompleted)
                    ActionItem.CompletedDateTime = ActionItemDto.CompletedDateTime;
            }
            
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
