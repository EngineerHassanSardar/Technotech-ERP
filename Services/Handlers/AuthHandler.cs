using Microsoft.Maui.Storage;
using System.Net.Http.Headers;
using Microsoft.Maui.Storage;
namespace Services.Handlers
{
    public class AuthHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Read the token from MAUI SecureStorage
            var token = await SecureStorage.Default.GetAsync("auth_token");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}