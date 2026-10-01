using AutoMapper;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using RentalCall.Repositories;
using RentalCall.Repositories.Interfaces;

namespace RentalCall.Managers
{
    public class UserRoleManager: IUserRoleManager
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        public UserRoleManager(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        //List all user roles
        public async Task<List<UserRoleModel>> List()
        {
            return await _userRoleRepository.List();
        }
    }
}
