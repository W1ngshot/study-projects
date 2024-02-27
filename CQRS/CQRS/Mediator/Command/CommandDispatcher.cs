namespace CQRS.Mediator.Command;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;  
  
    public CommandDispatcher(IServiceProvider serviceProvider)  
    {  
        _serviceProvider = serviceProvider;  
    }  
  
    public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand  
    {  
        var service = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;  
        await service!.HandleAsync(command);  
    }  
}