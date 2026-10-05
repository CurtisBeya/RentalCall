using Microsoft.EntityFrameworkCore;
using RentalCall.Models;
using RentalCall.Repositories.Interfaces;

namespace RentalCall.Repositories
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly RentalCallDbContext _rentalCallDbContext;
        private readonly ILogger<UserRepository> _logger;

        public AuthenticationRepository(RentalCallDbContext rentalCallDbContext, ILogger<UserRepository> logger)
        {
            _rentalCallDbContext = rentalCallDbContext;
            _logger = logger;
        }

        // Loging in an existing user.
        public UserModel? Login(UserModel user)
        {
            try
            {
                return _rentalCallDbContext.Users
                    .Include(x => x.UserRole)
                    .Where(x => x.EmailAddress == user.EmailAddress)
                    .FirstOrDefault();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a user details");
                throw new KeyNotFoundException($"Unable to return the user");
            }
        }

        // Reset password
        public async Task<UserModel?> PasswordReset(UserModel user)
        {
            try
            {
                // Find the user by condition
                var ExistingUser = _rentalCallDbContext.Users
                    .FirstOrDefault(x => x.EmailAddress == user.EmailAddress);

                if (ExistingUser != null)
                {
                    ExistingUser.UpdatedDateTime = DateTime.UtcNow;  
                    ExistingUser.Password = user.Password;
                    await _rentalCallDbContext.SaveChangesAsync();
                }

                return ExistingUser;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while Updating a user: {user.Id}", user);
                throw new DbUpdateException($"Unable to Update the database");
            }
        }
    }
}
