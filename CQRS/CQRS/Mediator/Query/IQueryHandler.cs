namespace CQRS.Mediator.Query;

public interface IQueryHandler<in TQuery, TOut>
    where TQuery : IQuery<TOut>
{
    Task<TOut> HandleAsync(TQuery query);  
}