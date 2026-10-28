using CommonModels.Auth;

namespace Core.BaseRepository
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginRequest request);
        Task LogoutAsync();
        Task<string?> GetTokenAsync();
    }
}