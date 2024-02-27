using Consumer;
using MassTransit;

var busControl = Bus.Factory.CreateUsingRabbitMq(configurator =>
{
    configurator.ReceiveEndpoint("message-created-event", endpointConfigurator =>
    {
        endpointConfigurator.Consumer<SomeConsumer>();
    });

});

await busControl.StartAsync();

try
{
    Console.WriteLine("Press enter to exit");

    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}


