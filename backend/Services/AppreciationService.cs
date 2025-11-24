using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class AppreciationService : IAppreciationService
    {
        private readonly ImprovDbContext _db;

        public AppreciationService(ImprovDbContext db)
        {
            _db = db;
        }

        public async Task<AppreciationResponse> CreateAsync(AppreciationRequest request)
        {
            var appreciation = new Appreciation
            {
                TargetUserId = request.ToUserId,
                Content = request.Content,
                DateCreated = DateTime.UtcNow
                // AuthorId sera ajouté côté AuthController si nécessaire
            };

            _db.Appreciations.Add(appreciation);
            await _db.SaveChangesAsync();

            return new AppreciationResponse
            {
                Id = appreciation.Id,
                ToUserId = appreciation.TargetUserId,
                FromUserId = appreciation.AuthorId,
                FromUserName = "", // si anonymisé, laisser vide
                Content = appreciation.Content,
                DateCreated = appreciation.DateCreated
            };
        }

        public async Task<List<AppreciationResponse>> GetReceivedByUserAsync(int userId)
        {
            var list = await _db.Appreciations
                .Where(a => a.TargetUserId == userId)
                .Include(a => a.Author)
                .ToListAsync();

            return list.Select(a => new AppreciationResponse
            {
                Id = a.Id,
                FromUserId = a.AuthorId,
                FromUserName = a.Author.Name,
                ToUserId = a.TargetUserId,
                Content = a.Content,
                DateCreated = a.DateCreated
            }).ToList();
        }

        public async Task<List<AppreciationResponse>> GetSentByUserAsync(int userId)
        {
            var list = await _db.Appreciations
                .Where(a => a.AuthorId == userId)
                .Include(a => a.TargetUser)
                .ToListAsync();

            return list.Select(a => new AppreciationResponse
            {
                Id = a.Id,
                FromUserId = a.AuthorId,
                FromUserName = a.Author.Name,
                ToUserId = a.TargetUserId,
                Content = a.Content,
                DateCreated = a.DateCreated
            }).ToList();
        }
    }
}