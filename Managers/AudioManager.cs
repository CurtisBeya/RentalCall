using AudioSummarizer.Managers.Interfaces;
using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;
using AudioSummarizer.Repositories;
using AudioSummarizer.Repositories.Interfaces;
using AutoMapper;

namespace AudioSummarizer.Managers
{
    public class AudioManager: IAudioManager
    {
        private readonly IAudioRepository _audioRepository;
        private readonly IMapper _mapper;
        public AudioManager(IAudioRepository audioRepository, IMapper mapper)
        {
            _audioRepository = audioRepository;
            _mapper = mapper;
        }

        // Adds a new audio
        public async Task<AudioModel> Add(AudioModelDto AudioDto)
        {
            AudioModel Audio = _mapper.Map<AudioModel>(AudioDto);
            return await _audioRepository.Add(Audio);
        }

        // Return the list of all audio summaries
        public async Task<List<AudioModel>> List()
        {
            return await _audioRepository.List();
        }

        // Return a specific audio summary
        public async Task<AudioModel?> Details(long AudioId)
        {
            return await _audioRepository.Details(AudioId);
        }
    }
}
