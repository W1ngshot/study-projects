using CookieApi.Dto;
using CookieApi.Models;

namespace CookieApi.Services;

public interface IComponentService
{
    public Task AddCpu(AddCpuDto dto);

    public Task AddRam(AddRamDto dto);
        
    public Task<IEnumerable<Cpu>> GetAllCpus();

    public Task<IEnumerable<Ram>> GetAllRams();

    public Task<(Cpu, Cpu)> CompareCpus(Guid idFirst, Guid idSecond);

    public Task<(Ram, Ram)> CompareRams(Guid idFirst, Guid idSecond);

    public Task Vote(Guid id);
}