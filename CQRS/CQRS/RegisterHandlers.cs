namespace CQRS;

public static class RegisterHandlers
{
    public static void AddHandlers(this IServiceCollection services, Type handlerInterface)
    {
        var handlers = typeof(Program).Assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface));
  
        foreach (var handler in handlers)
        {
            services.AddScoped(
                handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface),
                handler);
        }
    }
}