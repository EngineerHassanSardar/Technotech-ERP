using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.Maui.Storage;

// THIS LINE IS VERY IMPORTANT. Make sure it matches exactly.
namespace TechnotechInnovation.ERPMobile.Components
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await SecureStorage.Default.GetAsync("auth_token");

            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var identity = new ClaimsIdentity(new[] { new Claim("token", token) }, "apiauth");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public void NotifyUserAuthentication()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void NotifyUserLogout()
        {
            SecureStorage.Default.Remove("auth_token");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}