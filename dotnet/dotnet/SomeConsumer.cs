using MassTransit;

namespace dotnet;

public class SomeConsumer : IConsumer<Message>
{
    // При получении сообщения типа TechnicalObjectUploaded, выводим информацию о техничeском объекте
    public Task Consume(ConsumeContext<Message> context)
    {
        Console.WriteLine(context.Message.Text);
        return Task.CompletedTask;
    }
}