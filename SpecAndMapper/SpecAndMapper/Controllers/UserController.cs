using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

namespace SpecAndMapper.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    
    private List<User> _users = new()
    {
        new User {Id = 1, Name = "A", Password = "A)", Role = "User"},
        new User {Id = 2, Name = "B", Password = "B)", Role = "Admin"},
        new User {Id = 3, Name = "C", Password = "C)", Role = "User"},
        new User {Id = 4, Name = "D", Password = "D)", Role = "Admin"},
        new User {Id = 5, Name = "E", Password = "E)", Role = "User"},

    };

    public UserController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet("/admins")]
    public IEnumerable<PublicUser> GetAdmins()
    {
        return _users.Where(UserSpec.PublicUser.IsSatisfiedBy)
            .AsQueryable()
            .ProjectTo<PublicUser>(_mapper.ConfigurationProvider)
            .ToList();
    }
}