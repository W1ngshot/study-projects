using System.Security.Claims;
using CookieApi.Dto;
using CookieApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/register")]
    public async Task<string> Register(RegisterDto dto)
    {
        var claimsIdentity = await _userService.Register(dto);
        await Authenticate(claimsIdentity);
        return "Authorized";
    }
    
    [HttpPost("/login")]
    public async Task<string> Login(LoginDto dto)
    {
        var claimsIdentity = await _userService.Login(dto);
        await Authenticate(claimsIdentity);
        return "Authorized";
    }

    [HttpPost("/logout")]
    public async Task<string> Logout()
    {
        await HttpContext.SignOutAsync();
        return "Deauthorized";
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("/auth_check/admin")]
    public string CheckAdminAuth()
    {
        return "Success";
    }
    
    [Authorize(Roles = "User")]
    [HttpGet("/auth_check/user")]
    public string CheckUserAuth()
    {
        return "Success";
    }
    
    [Authorize]
    [HttpGet("/auth_check/any")]
    public string CheckAuth()
    {
        return "Success";
    }

    private async Task Authenticate(ClaimsIdentity identity)
    {
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));
    }
}