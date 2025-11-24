using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly PasswordHasher<User> _hasher = new();

        public string GenerateToken(User user)
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        public bool VerifyPassword(User user, string password)
        {
            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        public void SetPassword(User user, string password)
        {
            user.PasswordHash = _hasher.HashPassword(user, password);
        }
    }
}
