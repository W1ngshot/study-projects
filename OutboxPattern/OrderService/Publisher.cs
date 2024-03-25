using System.Text;
using Newtonsoft.Json;
using OrderService.Models;
using RabbitMQ.Client;
using IModel = RabbitMQ.Client.IModel;

namespace OrderService;

public interface IPublisher
{
    void Publish(OutboxOrder outboxOrder);
}

public class Publisher : IPublisher
{
    private readonly ILogger<Publisher> _logger;

    private readonly IModel _channel;

    public Publisher(ILogger<Publisher> logger)
    {
        _logger = logger;
        var factory = new ConnectionFactory {HostName = "localhost", Port = 5672};
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
        _channel.QueueDeclare(queue: "orderQueue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    public void Publish(OutboxOrder outboxOrder)
    {
        var message = JsonConvert.SerializeObject(outboxOrder);
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "",
            routingKey: "orderQueue",
            basicProperties: null,
            body: body);
        _logger.LogInformation("Order named {0} was pushed to rabbit", outboxOrder.Name);
    }
}