﻿namespace CQRS.Mediator.Query;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;  
  
    public QueryDispatcher(IServiceProvider serviceProvider)  
    {  
        _serviceProvider = serviceProvider;  
    }  
  
    public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>  
    {  
        var service = _serviceProvider.GetService(typeof(IQueryHandler<TQuery,TResult>)) as IQueryHandler<TQuery,TResult>;  
        return await service!.HandleAsync(query);  
    }
}