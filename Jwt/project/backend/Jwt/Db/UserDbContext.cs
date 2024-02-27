using Microsoft.EntityFrameworkCore;

namespace Jwt.Db;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new List<User>
        {
            new()
            {
                Id = 1,
                Username = "Admin",
                Password = "adminPas",
                Role = "admin"
            },
            new()
            {
                Id = 2,
                Username = "Moder",
                Password = "moderPas",
                Role = "moderator"
            },
            new()
            {
                Id = 3,
                Username = "User",
                Password = "userPas",
                Role = "user"
            }
        });
        base.OnModelCreating(modelBuilder);
    }
}