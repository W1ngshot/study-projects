using TimetableApi.Routing;

namespace TimetableApi.Endpoints;

public class TimetableEndpointRoot : IEndpointRoot
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("/timetable")
            .AddEndpoint<CreateTimetableEndpoint>();
    }
}