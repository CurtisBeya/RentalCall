using Microsoft.EntityFrameworkCore;
using RentalCall.Models;
using RentalCall.Repositories.Interfaces;

namespace RentalCall.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly RentalCallDbContext _RentalCallDbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(RentalCallDbContext RentalCallDbContext, ILogger<UserRepository> logger)
        {
            _RentalCallDbContext = RentalCallDbContext;
            _logger = logger;
        }

        // Adds a new user
        public async Task<UserModel> Add(UserModel User)
        {
            try
            {
                _RentalCallDbContext.Users.Add(User);
                await _RentalCallDbContext.SaveChangesAsync();
                return User;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while adding a user: {User.Id}", User);
                throw new DbUpdateException($"Unable to add to the database");
            }

        }

        //Updates an existing call
        public async Task<UserModel> Update(UserModel User)
        {
            try
            {
                _RentalCallDbContext.Users.Update(User);
                await _RentalCallDbContext.SaveChangesAsync();
                return User;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while updating a user: {User.Id}", User);
                throw new DbUpdateException($"Unable to add to the database");
            }

        }

        // Return the list of all users
        public async Task<List<UserModel>> List()
        {
            try
            {
                return await _RentalCallDbContext.Users.ToListAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a user list");
                throw new KeyNotFoundException($"Unable to return the list");
            }
        }

        // Return a specific user details
        public async Task<UserModel?> Details(long userId)
        {
            try
            {
                return await _RentalCallDbContext.Users.FindAsync(userId);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a user with the ID: {userId}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }
    }
}
