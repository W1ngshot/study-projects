using CQRS.SecurityHandlers;

namespace CQRS.Mediator.Command.Decorators;

public class CommandSecurityDecorator : ICommandDispatcher
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IServiceProvider _serviceProvider;

    public CommandSecurityDecorator(ICommandDispatcher commandDispatcher, IServiceProvider serviceProvider)
    {
        _commandDispatcher = commandDispatcher;
        _serviceProvider = serviceProvider;
    }

    public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
    {
        var service = _serviceProvider.GetService<ISecurityHandler<TCommand>>();
        if (service is not null)
        {
            var message = await service.HandleAsync(command);

            if (message is not null)
            {
                throw new UnauthorizedAccessException(message);
            }
        }

        await _commandDispatcher.Dispatch(command);
    }
}