using AudioSummarizer.Models.Dtos;
using AudioSummarizer.Models;
using AutoMapper;

namespace AudioSummarizer.Mapping
{
    public class MappingProfile: Profile
    {
        /// <summary>
        /// Mapping profiles for AutoMapping between different models and DTOs.
        /// </summary>
        /// 
        public MappingProfile() 
        {
            CreateMap<AudioModelDto, AudioModel>();
            CreateMap<ActionItemModelDto, ActionItemModel>();
        }
    }         
}
