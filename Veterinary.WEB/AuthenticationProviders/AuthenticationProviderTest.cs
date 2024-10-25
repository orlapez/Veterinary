using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;


namespace Veterinary.WEB.AuthenticationProviders
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var oapUser = new ClaimsIdentity(new List<Claim>
        {
            new Claim("Nombre", "Super"),
            new Claim("Apellido", "Administrador"),
            new Claim(ClaimTypes.Name, "orlapez@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin")
        },
        authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }

    }
}