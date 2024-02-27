using CookieApi.Database;
using CookieApi.HelperServices;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CookieApi.Bootstrap;

public static class HelperServicesBootstrap
{
    public static IServiceCollection AddHelperServices(this IServiceCollection services)
    {
        services.AddScoped<ClaimsIdentityGenerator>();
        services.AddScoped<CryptographyService>();
        services.AddScoped<DateTimeProvider>();
        services.AddScoped<DbSeeder>();
        
        services.AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(typeof(HelperServicesBootstrap).Assembly);
        
        return services;
    }
}