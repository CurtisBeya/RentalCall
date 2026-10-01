using RentalCall.Models;

namespace RentalCall.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // Adds a new user
        Task<UserModel> Add(UserModel User);

        //Updates an existing user
        Task<UserModel> Update(UserModel User);

        // Return the list of all users
        Task<List<UserModel>> List();

        // Return a specific user details
        Task<UserModel?> Details(long userId);
    }
}
