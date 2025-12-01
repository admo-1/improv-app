using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly ImprovDbContext _db;

        public UserService(ImprovDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetByIdAsync(int id)
            => await _db.Users
                .Include(u => u.SelfEvaluation)
                .Include(u => u.AuthoredAppreciations)
                .Include(u => u.ReceivedAppreciations)
                .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User?> GetByIdentifierAsync(string identifier)
            => await _db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == identifier);

        public async Task<List<User>> GetAllAsync()
            => await _db.Users.ToListAsync();

        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task SetPasswordAsync(User user, string newPassword)
        {
            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, newPassword);
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
