using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class SelfEvaluationService : ISelfEvaluationService
    {
        private readonly ImprovDbContext _db;

        public SelfEvaluationService(ImprovDbContext db)
        {
            _db = db;
        }

        public async Task<SelfEvaluationResponse?> GetByUserIdAsync(int userId)
        {
            var se = await _db.SelfEvaluations
                .FirstOrDefaultAsync(e => e.UserId == userId);

            if (se == null) return null;

            return new SelfEvaluationResponse
            {
                UserId = se.UserId,
                Content = se.Content,
                DateCreated = se.DateCreated
            };
        }

        public async Task<SelfEvaluationResponse> UpsertAsync(SelfEvaluationRequest request)
        {
            var existing = await _db.SelfEvaluations
                .FirstOrDefaultAsync(e => e.UserId == request.UserId);

            if (existing != null)
            {
                existing.Content = request.Content;
                existing.DateCreated = DateTime.UtcNow;
                _db.SelfEvaluations.Update(existing);
            }
            else
            {
                existing = new SelfEvaluation
                {
                    UserId = request.UserId,
                    Content = request.Content,
                    DateCreated = DateTime.UtcNow
                };
                await _db.SelfEvaluations.AddAsync(existing);
            }

            await _db.SaveChangesAsync();

            return new SelfEvaluationResponse
            {
                UserId = existing.UserId,
                Content = existing.Content,
                DateCreated = existing.DateCreated
            };
        }
    }
}
