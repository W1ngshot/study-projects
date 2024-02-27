using CookieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CookieApi.Database;

public class AppDbContext : DbContext
{
    private readonly DbSeeder _seeder;
    
    public DbSet<User> Users { get; set; }
    public DbSet<Accessory> Accessories { get; set; }
    public DbSet<Cpu> Cpus { get; set; }
    public DbSet<Ram> Rams { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, DbSeeder seeder) : base(options)
    {
        _seeder = seeder;
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        builder.Entity<User>()
            .HasData(_seeder.GetDefaultUsersForDb());
    }
}