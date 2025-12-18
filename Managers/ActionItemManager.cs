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
        public ActionItemManager(IActionItemRepository actionItemRepositury, Mapper mapper)
        {
            _actionItemRepository = actionItemRepositury;
            _mapper = mapper;
        }

        //adds an action item
        public Task<ActionItemModel> Add(ActionItemModelDto ActionItemDto)
        {
            ActionItemModel ActionItem = _mapper.Map<ActionItemModel>(ActionItemDto);
            return _actionItemRepository.Add(ActionItem);
        }

        //Updates an action item
        public Task<ActionItemModel> Update(ActionItemModelDto ActionItemDto)
        {
            ActionItemModel ActionItem = _mapper.Map<ActionItemModel>(ActionItemDto);
            return _actionItemRepository.Update(ActionItem);
        }

        // Return the list of all action items
        public Task<List<ActionItemModel>> List()
        {
            return _actionItemRepository.List();
        }

        // Return a specific Action Item summary
        public Task<ActionItemModel?> Details(long ActionItemId)
        {
            return _actionItemRepository.Details(ActionItemId);
        }
    }
}
