namespace CQRS.Mediator.Query.Decorators;

public class QueryLoggingDecorator : IQueryDispatcher
{
    private readonly IQueryDispatcher _queryDispatcher;

    public QueryLoggingDecorator(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
    {
        var result = await _queryDispatcher.Dispatch<TQuery, TResult>(query);
        
        Console.WriteLine($"Call {typeof(TQuery)} with {query.ToString()}, response: {result.ToString()}");
        return result;
    }
}