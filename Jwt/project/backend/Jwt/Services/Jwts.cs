using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Jwt.Db;
using Microsoft.IdentityModel.Tokens;

namespace Jwt.Services;

public class Jwts : IJwt
{
    private readonly UserContext _context;

    public Jwts(UserContext context)
    {
        _context = context;
    }

    public string GenerateJwtToken(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        if (user is null)
            return null;
        var now = DateTime.Now;

        var jwt = new JwtSecurityToken(
            issuer: "issuer",
            audience: "audience",
            notBefore: now,
            claims: GetIdentity(user.Username, user.Role).Claims,
            expires: now.Add(TimeSpan.FromMinutes(5)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                    "the_most_secret_key_ever-_-_1232141241241241256316263432432786475"u8.ToArray()),
                SecurityAlgorithms.HmacSha256)
        );
        var encoded = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encoded;
    }

    private ClaimsIdentity GetIdentity(string username, string role)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, username),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}