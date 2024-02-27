using CookieApi.Services;

namespace CookieApi.Bootstrap;

public static class ServicesBootstrap
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IComponentService, ComponentService>();
        services.AddScoped<IRatingService, RatingService>();
        
        return services;
    }
}