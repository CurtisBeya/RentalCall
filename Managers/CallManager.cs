using RentalCall.Enums;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using RentalCall.Models.Dtos;
using RentalCall.Repositories;
using RentalCall.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Hosting;

namespace RentalCall.Managers
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
            //check if call exists in the database to avoid duplicates

            if(await _callRepository.SearchGivenAudioFileName(CallDto.AudioFileName) != null)
                throw new ArgumentException($"A call already exists with this file name: {CallDto.AudioFileName}");

            String CallCategoryName = "Reservations";          //to get from the transcription service

            CallCategoryModel? CallCategory = await _callCategoryRepository.DetailsGivenCallCategoryName(CallCategoryName);

            CallModel Call = _mapper.Map<CallModel>(CallDto);

            Call.Summary = "Client is requesting a call back"; //to get from the transcription service
            Call.CallCategoryId = CallCategory.Id;
            Call.CallCategoryConfidence = 0.70;               // to get from the transcription service
            Call.HasActionItemError = false;
            Call.HasBeenReviewed = false;
            Call.CreatedDateTime = DateTime.Now;

            // the call is saved first even if action items fail
            CallModel SavedCall = await _callRepository.Add(Call); 

            //create ActionItems
            var ActionItemTexts = new List<String>();

            ActionItemTexts.Add("item action test 4");
            ActionItemTexts.Add("item action test 5");
            ActionItemTexts.Add("item action test 6");

            foreach (var text in ActionItemTexts)
            {
                try
                {
                    await _actionItemManager.SystemAdd(text, SavedCall.Id);
                }
                catch (Exception ex)
                {
                    // set call has action item error to true
                    SavedCall.HasActionItemError = true;
                }              
            }

            // update the call if there was an action item that failed to save
            if (SavedCall.HasActionItemError)
            {
                SavedCall.UpdatedDateTime = DateTime.UtcNow;
                await _callRepository.Update(SavedCall);
            }

            return SavedCall;
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

        // Update HasBeen reviewed automatically when an ActionItem is added manually to a call
        public async Task<CallModel> CallReviewSystemUpdate(long CallId)
        {
            //Request existing model
            CallModel? Call = await Details(CallId);

            //Update the model
            Call.HasBeenReviewed = true;
            Call.UpdatedDateTime = DateTime.UtcNow;

            return await _callRepository.Update(Call);
        }

        // Return the list of all calls
        public async Task<List<CallModel>> List()
        {
            return await _callRepository.List();
        }

        public async Task<List<CallModel>> ListGivenCategoryName(String CategoryName)
        {
            //get Category Id

            var CallCategoryEnum = CategoryName.GetCallCategoryEnumFromString();
            CallCategoryModel? CallCategory = await _callCategoryRepository.DetailsGivenCallCategoryName(CallCategoryEnum.ToString());

            return await _callRepository.ListGivenCategoryId(CallCategory.Id);
        }

        // Return a specific call 
        public async Task<CallModel?> Details(long AudioId)
        {
            return await _callRepository.Details(AudioId);
        }

        // Return a specific call given the file name
        public async Task<CallModel?> SearchGivenAudioFileName(String AudioFileName)
        {
            return await _callRepository.SearchGivenAudioFileName(AudioFileName);
        }
    }
}
