using RentalCall.Models;
using RentalCall.Models.Dtos;

namespace RentalCall.Managers.Interfaces
{
    public interface IUserManager
    {
        // Adds a new user
        Task<UserModel> Add(UserCreateModelDto UserDto);

        //Updates an existing user
        Task<UserModel> Update(UserUpdateModelDto CallDto);

        // Return the list of all users
        Task<List<UserModel>> List();

        // Return a specific user summary
        Task<UserModel?> Details(long userId);
    }
}
