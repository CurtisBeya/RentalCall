using RentalCall.Models;

namespace RentalCall.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        // Login
        UserModel? Login(UserModel user);

        // Reset
        Task<UserModel?> PasswordReset(UserModel user);
    }
}
