using AutoMapper;
using Microsoft.EntityFrameworkCore.Update;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using RentalCall.Models.Dtos;
using RentalCall.Repositories;
using RentalCall.Repositories.Interfaces;

namespace RentalCall.Managers
{
    public class UserManager: IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // Adds a new user
        public async Task<UserModel> Add(UserCreateModelDto UserDto)
        {
            UserModel User = _mapper.Map<UserModel>(UserDto);

            User.IsActive = true;
            User.CreatedDateTime = DateTime.Now;

            return await _userRepository.Update(User);
        }

        //Updates an existaing user
        public async Task<UserModel> Update(UserUpdateModelDto UserDto)
        {
            //Request existing model
            UserModel? User = await _userRepository.Details(UserDto.Id);

            User.UserRoleId = UserDto.UserRoleId;
            User.UpdatedDateTime = DateTime.Now;

            return await _userRepository.Update(User);
        }

        //List all users
        public async Task<List<UserModel>> List()
        {
            return await _userRepository.List();
        }

        //details of a specific user
        public async Task<UserModel> Details(long userId)
        {
            return await _userRepository.Details(userId);
        }
    }
}
