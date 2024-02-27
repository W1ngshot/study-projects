using System.Security.Claims;
using CookieApi.Models;

namespace CookieApi.HelperServices;

public class ClaimsIdentityGenerator
{
    public ClaimsIdentity GenerateUserClaimsIdentity(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
        };

        return new ClaimsIdentity(claims, "ApplicationCookie", 
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
    }

}