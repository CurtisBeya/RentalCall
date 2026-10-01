using RentalCall.Models;

namespace RentalCall.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        // Return the list of all user roles
        Task<List<UserRoleModel>> List();

        // Return a specific user role details given the user role id
        Task<UserRoleModel?> Details(long userRoleId);

        // Return a specific user role details given the user role name
        Task<UserRoleModel?> DetailsGivenUserRoleName(String userRoleName);
    }
}
