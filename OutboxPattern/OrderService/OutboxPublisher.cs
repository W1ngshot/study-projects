using Microsoft.EntityFrameworkCore;

namespace OrderService;

public class OutboxPublisher(
    ILogger<OutboxPublisher> logger,
    IPublisher publisher,
    IServiceProvider serviceProvider)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var outboxEvents = await context.OutboxOrders.OrderBy(x => x.AddDate)
                    .ToListAsync(cancellationToken: cancellationToken);
                foreach (var outboxEvent in outboxEvents)
                {
                    publisher.Publish(outboxEvent);
                    context.OutboxOrders.Remove(outboxEvent);
                    await context.SaveChangesAsync(cancellationToken);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in publishing: {ex.Message}");
            }
            finally
            {
                await Task.Delay(30000, cancellationToken);
            }
        }
    }
}