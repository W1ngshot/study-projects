using MassTransit;

namespace dotnet;

public class KeyHostedService : BackgroundService
{
    private readonly IBus _bus;
    
    
    public KeyHostedService(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var key = Console.ReadKey();
            
            await _bus.Publish(new Message($"Клавиша {key.Key} была нажата"), stoppingToken);
        }

        return;
    }
}