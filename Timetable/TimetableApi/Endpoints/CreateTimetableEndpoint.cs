using Microsoft.AspNetCore.Mvc;
using TimetableApi.Dto;
using TimetableApi.Handlers;
using TimetableApi.Routing;

namespace TimetableApi.Endpoints;

public class CreateTimetableEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/",
            async (CreateTimetableDto dto, CreateTimetableHandler handler) =>
            {
                await handler.CreateTimetable(dto);
                return Results.Ok();
            });
    }
}