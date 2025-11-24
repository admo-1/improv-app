using backend.DTOs;

namespace backend.Services
{
    public interface IAppreciationService
    {
        Task<AppreciationResponse> CreateAsync(AppreciationRequest request);
        Task<List<AppreciationResponse>> GetReceivedByUserAsync(int userId);
        Task<List<AppreciationResponse>> GetSentByUserAsync(int userId);
    }
}
