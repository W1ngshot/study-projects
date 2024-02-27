using System.Security.Claims;
using CookieApi.Dto;

namespace CookieApi.Services;

public interface IUserService
{
    Task<ClaimsIdentity> Register(RegisterDto dto);

    Task<ClaimsIdentity> Login(LoginDto dto);
    
    
}