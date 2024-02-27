namespace CQRS.Routing;

public interface IEndpoint
{
    public void Map(IEndpointRouteBuilder endpoints);
}