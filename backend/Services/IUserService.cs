using backend.Models;

namespace backend.Services
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByIdentifierAsync(string identifier);
        Task<List<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task AddAsync(User user);
    }
}
