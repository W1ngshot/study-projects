using CQRS.Features.Profile;
using CQRS.Features.SetProfileId;
using CQRS.Routing;

namespace CQRS.Features;

public class ProfileEndpointRoot : IEndpointRoot
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("/a")
            .WithTags("Пользователь")
            .AddEndpoint<GetProfileEndpoint>()
            .AddEndpoint<SetProfileEndpoint>();
    }
}