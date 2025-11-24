using backend.Models;

namespace backend.Services
{
    public interface IAuthService
    {
        string GenerateToken(User user);
        bool VerifyPassword(User user, string password);
        void SetPassword(User user, string password);
    }
}
