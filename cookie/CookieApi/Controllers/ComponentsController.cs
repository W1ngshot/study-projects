using CookieApi.Dto;
using CookieApi.Models;
using CookieApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ComponentsController : ControllerBase
{
    private readonly IComponentService _componentService;

    public ComponentsController(IComponentService componentService)
    {
        _componentService = componentService;
    }

    [Authorize(Roles = "admin")]
    [HttpPost("cpu/add")]
    public async Task AddCpu(AddCpuDto cpu)
    {
        await _componentService.AddCpu(cpu);
    }

    [HttpGet("cpu/compare")]
    public async Task<(Cpu, Cpu)> CompareCpus(Guid idFirst, Guid idSecond)
    {
        return await _componentService.CompareCpus(idFirst, idSecond);
        
    }

    [HttpGet("cpu/all")]
    public async Task<IEnumerable<Cpu>> GetAllCpus()
    {
        return await _componentService.GetAllCpus();
    }

    [Authorize(Roles = "user")]
    [HttpPost("vote")]
    public async Task Vote(Guid id)
    {
        await _componentService.Vote(id);
    }

    [Authorize(Roles = "admin")]
    [HttpPost("ozu/add")]
    public async Task AddRam(AddRamDto ram)
    {
        await _componentService.AddRam(ram);
    }

    [HttpGet("ozu/compare")]
    public async Task<(Ram, Ram)> CompareRams(Guid idFirst, Guid idSecond)
    {
        return await _componentService.CompareRams(idFirst, idSecond);
    }

    [HttpGet("ozu/all")]
    public async Task<IEnumerable<Ram>> GetAllRams()
    {
        return await _componentService.GetAllRams();
    }
}