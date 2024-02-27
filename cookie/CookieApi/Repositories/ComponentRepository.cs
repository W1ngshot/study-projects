using CookieApi.Database;
using CookieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CookieApi.Repositories;

public class ComponentRepository : IComponentRepository
{
    private readonly AppDbContext _context;

    public ComponentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cpu?> GetCpuByIdAsync(Guid id)
    {
        return await _context.Cpus
            .FirstOrDefaultAsync(cpu => cpu.Id == id);
    }

    public async Task<IEnumerable<Cpu>> GetAllCpusAsync()
    {
        return await _context.Cpus
            .Include(cpu => cpu.Rating)
            .ToListAsync();
    }

    public async Task<Ram?> GetRamByIdAsync(Guid id)
    {
        return await _context.Rams
            .FirstOrDefaultAsync(ram => ram.Id == id);
    }

    public async Task<IEnumerable<Ram>> GetAllRamsAsync()
    {
        return await _context.Rams
            .Include(ram => ram.Rating)
            .ToListAsync();
    }

    public async Task<Accessory?> GetComponentByIdAsync(Guid id)
    {
        return await _context.Accessories
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddCpuAsync(Cpu cpu)
    {
        await _context.Cpus.AddAsync(cpu);
    }

    public async Task AddRamAsync(Ram ram)
    {
        await _context.Rams.AddAsync(ram);
    }

    public async Task<IEnumerable<Accessory>> GetAllAccessories()
    {
        return await _context.Accessories
            .Include(a => a.Rating)
            .ToListAsync();
    }
}