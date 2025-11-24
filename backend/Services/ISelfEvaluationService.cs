using backend.DTOs;

namespace backend.Services
{
    public interface ISelfEvaluationService
    {
        Task<SelfEvaluationResponse?> GetByUserIdAsync(int userId);
        Task<SelfEvaluationResponse> UpsertAsync(SelfEvaluationRequest request);
    }
}
