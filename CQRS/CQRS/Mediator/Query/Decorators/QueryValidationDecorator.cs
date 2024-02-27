using FluentValidation;

namespace CQRS.Mediator.Query.Decorators;

public class QueryValidationDecorator : IQueryDispatcher
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IServiceProvider _serviceProvider;

    public QueryValidationDecorator(IQueryDispatcher queryDispatcher, IServiceProvider serviceProvider)
    {
        _queryDispatcher = queryDispatcher;
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
    {
        var validator = _serviceProvider.GetService<IValidator<TQuery>>();

        if (validator is null) 
            return await _queryDispatcher.Dispatch<TQuery, TResult>(query);
        
        var validationResult = await validator.ValidateAsync(query);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors.Select(failure =>
                    $"{failure.PropertyName}: {failure.ErrorMessage}")
                .Aggregate("Failures:\n", (first, next) => $"{first}\n{next}"));
        }

        return await _queryDispatcher.Dispatch<TQuery, TResult>(query);
    }
}