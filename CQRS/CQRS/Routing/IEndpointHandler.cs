namespace CQRS.Routing;

public interface IEndpointHandler<in TRequest, TResponse>
{
    public Task<TResponse> Handle(TRequest request);
}