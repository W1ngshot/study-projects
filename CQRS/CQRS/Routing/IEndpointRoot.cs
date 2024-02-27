namespace CQRS.Routing;

public interface IEndpointRoot
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints);
}