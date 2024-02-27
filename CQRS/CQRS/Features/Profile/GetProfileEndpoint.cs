using CQRS.Mediator.Query;
using CQRS.Routing;

namespace CQRS.Features.Profile;

public class GetProfileEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/{id:int}",
            async (int id, IQueryDispatcher dispatcher) =>
                Results.Ok(await dispatcher.Dispatch<GetProfileQuery, int>(new GetProfileQuery(id))));
    }
}