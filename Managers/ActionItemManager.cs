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
        public async Task<ActionItemModel> Add(String Description, long CallId)
        {
            ActionItemModel ActionItem= new ActionItemModel();

            ActionItem.Description = Description;
            ActionItem.CallId = CallId;
            ActionItem.AssignedToDepartment = false;
            ActionItem.IsCompleted = false;
            ActionItem.CreatedDateTime = DateTime.Now;

            return await _actionItemRepository.Add(ActionItem);
        }

        //Updates an action item
        public async Task<ActionItemModel> Update(ActionItemModelDto ActionItemDto)
        {
            ActionItemModel ActionItem = _mapper.Map<ActionItemModel>(ActionItemDto);
            return await _actionItemRepository.Update(ActionItem);
        }

        // Return the list of all action items
        public async Task<List<ActionItemModel>> List()
        {
            return await _actionItemRepository.List();
        }

        // Return a specific Action Item summary
        public async Task<ActionItemModel?> Details(long ActionItemId)
        {
            return await _actionItemRepository.Details(ActionItemId);
        }
    }
}
