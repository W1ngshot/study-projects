using CookieApi.Models;

namespace CookieApi.Repositories;

public interface IComponentRepository
{
    public Task<Cpu?> GetCpuByIdAsync(Guid id);

    public Task<IEnumerable<Cpu>> GetAllCpusAsync();

    public Task<Ram?> GetRamByIdAsync(Guid id);

    public Task<IEnumerable<Ram>> GetAllRamsAsync();

    public Task<Accessory?> GetComponentByIdAsync(Guid id);

    public Task AddCpuAsync(Cpu cpu);

    public Task AddRamAsync(Ram ram);

    public Task<IEnumerable<Accessory>> GetAllAccessories();
}