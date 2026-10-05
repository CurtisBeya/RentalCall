using RentalCall.Models;
using RentalCall.Models.Dtos;

namespace RentalCall.Managers.Interfaces
{
    public interface IAuthenticationManager
    {
        // Login
        UserModel? Login(LoginDetailsDto loginDetailsDto);

        // Reset
        Task<UserModel?> PasswordReset(LoginDetailsDto passwordResetDto);
    }
}

