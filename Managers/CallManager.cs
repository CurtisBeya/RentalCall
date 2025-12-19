using AudioSummarizer.Managers.Interfaces;
using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;
using AudioSummarizer.Repositories;
using AudioSummarizer.Repositories.Interfaces;
using AutoMapper;

namespace AudioSummarizer.Managers
{
    public class CallManager: ICallManager
    {
        private readonly ICallRepository _callRepository;
        private readonly IMapper _mapper;
        public CallManager(ICallRepository callRepository, IMapper mapper)
        {
            _callRepository = callRepository;
            _mapper = mapper;
        }

        // Adds a new call
        public async Task<CallModel> Add(CallModelDto CallDto)
        {
            CallModel Call = _mapper.Map<CallModel>(CallDto);
            return await _callRepository.Add(Call);
        }

        // Return the list of all call summaries
        public async Task<List<CallModel>> List()
        {
            return await _callRepository.List();
        }

        // Return a specific call summary
        public async Task<CallModel?> Details(long AudioId)
        {
            return await _callRepository.Details(AudioId);
        }
    }
}
