namespace CQRS.Mediator.Query;

public interface IQueryDispatcher  
{  
    Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;  
}