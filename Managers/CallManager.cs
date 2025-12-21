using AudioSummarizer.Enums;
using AudioSummarizer.Managers.Interfaces;
using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;
using AudioSummarizer.Repositories;
using AudioSummarizer.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Hosting;

namespace AudioSummarizer.Managers
{
    public class CallManager: ICallManager
    {
        private readonly ICallRepository _callRepository;
        private readonly ICallCategoryRepository _callCategoryRepository;
        private readonly IActionItemManager _actionItemManager;
        private readonly IMapper _mapper;
        public CallManager(ICallRepository callRepository, ICallCategoryRepository callCategoryrepository, IActionItemManager actionItemManager, IMapper mapper)
        {
            _callRepository = callRepository;
            _callCategoryRepository = callCategoryrepository; 
            _actionItemManager = actionItemManager;
            _mapper = mapper;
        }

        // Adds a new call
        public async Task<CallModel> Add(CallCreateModelDto CallDto)
        {
            String CallCategoryName = "Reservations";          //to get from the transcribe service

            CallCategoryModel? CallCategory = await _callCategoryRepository.DetailsGivenCallCategoryName(CallCategoryName);

            CallModel Call = _mapper.Map<CallModel>(CallDto);

            Call.Summary = "Client is requesting a cottation"; //to get from the transcribe service
            Call.CallCategoryId = CallCategory.Id;
            Call.CallCategoryConfidence = 0.70;               // to get from the transcribe service
            Call.HasActionItemError = false;
            Call.HasBeenReviewed = false;
            Call.CreatedDateTime = DateTime.Now;

            // the call is saved first even if action items fail

            await _callRepository.Add(Call); 

            //creates ActionItems

            var ActionItemTexts = new List<String>();

            foreach (var text in ActionItemTexts)
            {
                try
                {
                    await _actionItemManager.Add(text, Call.Id);
                }
                catch (Exception ex)
                {
                    // set call has action item error to true

                    Call.HasActionItemError = true;
                }              
            }

            // update the call if there was an action item that failed to save
            if (Call.HasActionItemError)
            {
                Call.UpdatedDateTime = DateTime.UtcNow;
                await _callRepository.Update(Call);
            }

            return Call;
        }

        // Update a call
        public async Task<CallModel> Update(CallUpdateModelDto CallDto)
        {
            //Request existing model
            CallModel? Call = await Details(CallDto.Id);

            //Update the model
            Call.HasBeenReviewed = CallDto.HasBeenReviewed;
            Call.UpdatedDateTime = DateTime.UtcNow;

            return await _callRepository.Update(Call);
        }

        // Return the list of all calls
        public async Task<List<CallModel>> List()
        {
            return await _callRepository.List();
        }

        // Return a specific call 
        public async Task<CallModel?> Details(long AudioId)
        {
            return await _callRepository.Details(AudioId);
        }
    }
}
