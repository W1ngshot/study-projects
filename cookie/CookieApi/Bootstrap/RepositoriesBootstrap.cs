using CookieApi.Repositories;

namespace CookieApi.Bootstrap;

public static class RepositoriesBootstrap
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<UserRepository>();
        services.AddScoped<IComponentRepository, ComponentRepository>();

        return services;
    }
}