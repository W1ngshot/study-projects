namespace CookieApi.Bootstrap;

public static class SwaggerWithCookieBootstrap
{
    public static IServiceCollection AddSwaggerWithCookie(this IServiceCollection services)
    {
        services.AddSwaggerGen();

        return services;
    }
}