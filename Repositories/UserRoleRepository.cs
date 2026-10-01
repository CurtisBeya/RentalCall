using Microsoft.EntityFrameworkCore;
using RentalCall.Models;
using RentalCall.Repositories.Interfaces;

namespace RentalCall.Repositories
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly RentalCallDbContext _RentalCallDbContext;
        private readonly ILogger<UserRoleRepository> _logger;

        public UserRoleRepository(RentalCallDbContext RentalCallDbContext, ILogger<UserRoleRepository> logger)
        {
            _RentalCallDbContext = RentalCallDbContext;
            _logger = logger;
        }

        // Returs the list of all user roles
        public async Task<List<UserRoleModel>> List()
        {
            try
            {
                return await _RentalCallDbContext.UserRoles.ToListAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a list of user roles");
                throw new KeyNotFoundException($"Unable to return the list");
            }
        }

        // Returns a specific user role details given the user role ID
        public async Task<UserRoleModel?> Details(long userRoleId)
        {
            try
            {
                return await _RentalCallDbContext.UserRoles.FindAsync(userRoleId);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a user role with the ID: {userRoleId}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }

        // Returns a specific user role details given the user role name
        public async Task<UserRoleModel?> DetailsGivenUserRoleName(String UserRoleName)
        {
            try
            {
                return await _RentalCallDbContext.UserRoles
                    .Where(x => x.Name == UserRoleName)
                    .FirstOrDefaultAsync();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving a call category with the name: {UserRoleName}");
                throw new KeyNotFoundException($"Unable to query the database");
            }
        }
    }
}
