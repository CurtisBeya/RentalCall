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
        public AudioManager(IAudioRepository audioRepositury, Mapper mapper)
        {
            _audioRepository = audioRepositury;
            _mapper = mapper;
        }

        // Adds a new audio
        public Task<AudioModel> Add(AudioModelDto AudioDto)
        {
            AudioModel Audio = _mapper.Map<AudioModel>(AudioDto);
            return _audioRepository.Add(Audio);
        }

        // Return the list of all audio summaries
        public Task<List<AudioModel>> List()
        {
            return _audioRepository.List();
        }

        // Return a specific audio summary
        public Task<AudioModel?> Details(long AudioId)
        {
            return _audioRepository.Details(AudioId);
        }
    }
}
