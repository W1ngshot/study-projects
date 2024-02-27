using Jwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<AuthController> _logger;
    private readonly IJwt _jwt;

    public AuthController(ILogger<AuthController> logger, IJwt jwt)
    {
        _logger = logger;
        _jwt = jwt;
    }

    [HttpGet("/moderator")]
    [Authorize(Roles = "moderator")]
    public string Moderator()
    {
        return "Moderator auth success";
    }

    [HttpGet("/admin")]
    [Authorize(Roles = "admin")]
    public string Admin()
    {
        return "Admin auth success";
    }

    [HttpGet("/user")]
    [Authorize(Roles = "user")]
    public string GetUser()
    {
        return "User auth success";
    }

    [HttpPost("/login")]
    public string Login(LoginDto dto)
    {
        return _jwt.GenerateJwtToken(dto.Username, dto.Password);
    }
}