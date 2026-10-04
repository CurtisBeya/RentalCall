using RentalCall.Models.Dtos;
using RentalCall.Models;
using AutoMapper;

namespace RentalCall.Mapping
{
    public class MappingProfile: Profile
    {
        /// <summary>
        /// Mapping profiles for AutoMapping between different models and DTOs.
        /// </summary>
        /// 
        public MappingProfile() 
        {
            CreateMap<CallCreateModelDto, CallModel>();
            CreateMap<CallUpdateModelDto, CallModel>();
            CreateMap<ActionItemCreateModelDto, ActionItemModel>();
            CreateMap<UserCreateModelDto, UserModel>();
        }
    }         
}
