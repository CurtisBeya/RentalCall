namespace RentalCall.Enums
{
    internal enum UserRoleEnum
    {
        Admin,
        DepartmentManager,
        User
    }

    internal static class UserRoleExtensions
    {
        public static UserRoleEnum GetUserRoleEnumFromString(this String UserRole)
        {
            if (Enum.TryParse<UserRoleEnum>(UserRole.Trim(), true, out var result))
                return result;

            throw new ArgumentException($"Invalid status: {UserRole}");
        }
    }
}
