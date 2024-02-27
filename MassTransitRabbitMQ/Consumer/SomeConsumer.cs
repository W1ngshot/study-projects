using MassTransit;
using Newtonsoft.Json;
using SharedModels;

namespace Consumer;

class SomeConsumer : IConsumer<MessageCreated>
{
    public Task Consume(ConsumeContext<MessageCreated> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"Message: {jsonMessage}");
        return Task.CompletedTask;
    }
}