using CQRS.Mediator.Command;

namespace CQRS.SecurityHandlers;

public interface ISecurityHandler<in TCommand> where TCommand : ICommand
{
    Task<string?> HandleAsync(TCommand command);
}