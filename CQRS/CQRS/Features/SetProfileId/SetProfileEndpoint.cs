using CQRS.Mediator.Command;
using CQRS.Routing;

namespace CQRS.Features.SetProfileId;

public class SetProfileEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/{id:int}",
            async (int id, ICommandDispatcher dispatcher) =>
            {
                await dispatcher.Dispatch(new SetProfileCommand(id));
            });
    }
}