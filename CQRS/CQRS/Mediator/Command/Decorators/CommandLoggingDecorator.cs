using CQRS.Mediator.Query;

namespace CQRS.Mediator.Command.Decorators;

public class CommandLoggingDecorator : ICommandDispatcher
{
    private readonly ICommandDispatcher _commandDispatcher;

    public CommandLoggingDecorator(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
    {
        await _commandDispatcher.Dispatch(command);
        
        Console.WriteLine($"Call {typeof(TCommand)} with {command.ToString()}");
    }
}