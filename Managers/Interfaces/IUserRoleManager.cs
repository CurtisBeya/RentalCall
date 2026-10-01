using RentalCall.Models;

namespace RentalCall.Managers.Interfaces
{
    public interface IUserRoleManager
    {
        // Return the list of all user roles
        Task<List<UserRoleModel>> List();
    }
}
