using CookieApi.Database;
using Microsoft.EntityFrameworkCore;

namespace CookieApi.Bootstrap;

public static class DatabaseBootstrap
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options
            .UseNpgsql(configuration.GetConnectionString("Postgres"))
            .UseSnakeCaseNamingConvention());
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}