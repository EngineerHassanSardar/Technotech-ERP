using System.Net.Http.Json;
using CommonModels.Auth;
using Core.BaseRepository;
using Microsoft.Maui.Storage;
namespace Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> LoginAsync(LoginRequest request)
        {
            // Note: Change "api/login" to your actual API endpoint
            var response = await _http.PostAsJsonAsync("api/login", request);

            if (!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (result != null && !string.IsNullOrEmpty(result.Token))
            {
                // Save token securely in the app
                await SecureStorage.Default.SetAsync("auth_token", result.Token);
                return true;
            }

            return false;
        }

        public Task LogoutAsync()
        {
            SecureStorage.Default.Remove("auth_token");
            return Task.CompletedTask;
        }

        public async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.Default.GetAsync("auth_token");
        }
    }
}