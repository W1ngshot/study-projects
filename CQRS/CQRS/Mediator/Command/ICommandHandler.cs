
namespace CQRS.Mediator.Command;

public interface ICommandHandler<in TCommand> 
    where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}