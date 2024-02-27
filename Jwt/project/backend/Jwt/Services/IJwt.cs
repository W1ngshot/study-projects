namespace Jwt.Services;

public interface IJwt
{
    string GenerateJwtToken(string username, string password);
}