using FluentValidation;

namespace CQRS.Mediator.Command.Decorators;

public class CommandValidationDecorator : ICommandDispatcher
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IServiceProvider _serviceProvider;

    public CommandValidationDecorator(ICommandDispatcher commandDispatcher, IServiceProvider serviceProvider)
    {
        _commandDispatcher = commandDispatcher;
        _serviceProvider = serviceProvider;
    }

    public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
    {
        var validator = _serviceProvider.GetService<IValidator<TCommand>>();

        if (validator is null)
        {
            await _commandDispatcher.Dispatch(command);
            return;            
        }
        
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors.Select(failure =>
                    $"{failure.PropertyName}: {failure.ErrorMessage}")
                .Aggregate("Failures:\n", (first, next) => $"{first}\n{next}"));
        }

        await _commandDispatcher.Dispatch(command);
    }
}