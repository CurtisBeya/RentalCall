using Microsoft.AspNetCore.Identity;
using RentalCall.Services.Interfaces;

//HashPassword → Generates a salted, secure hash (PBKDF2 by default).

//VerifyHashedPassword → Compares a stored hash with a plain password.

//No need to manually handle salts — they are embedded in the hash string


namespace RentalCall.Services
{
    public class PasswordService: IPasswordService
    {
        private readonly IPasswordHasher<object> _passwordHasher;

        public PasswordService(IPasswordHasher<object> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
