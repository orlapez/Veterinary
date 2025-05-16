using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace VeterinaryWEB.Auth
{
    public class AuthenticationProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var anonimous = new ClaimsIdentity();
            var oapUser = new ClaimsIdentity(new List<Claim>
        {
            new Claim("FirstName", "Luis"),
            new Claim("LastName", "O"),
            new Claim(ClaimTypes.Name, "orlapez@gmail.com"),
                    new Claim(ClaimTypes.Role, "Admin")
        },
                authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }
    }
}
