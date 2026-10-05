using AutoMapper;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using RentalCall.Models.Dtos;
using RentalCall.Repositories.Interfaces;

namespace RentalCall.Managers
{
    public class AuthenticationManager: IAuthenticationManager
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public AuthenticationManager(IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        // Loging in an existing user.
        public UserModel? Login(LoginDetailsDto loginDetailsDto)
        {
            UserModel user = _mapper.Map<UserModel>(loginDetailsDto);
            return _authenticationRepository.Login(user);
        }

        // Reset password an existing user.
        public async Task<UserModel?> PasswordReset(LoginDetailsDto PasswordReset)
        {
            UserModel user = _mapper.Map<UserModel>(PasswordReset);
            return await _authenticationRepository.PasswordReset(user);
        }
    }
}
