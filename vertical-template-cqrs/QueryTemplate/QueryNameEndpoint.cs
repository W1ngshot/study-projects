using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Messenger.Core.Services;
using Messenger.Infrastructure.Endpoints;

namespace Messenger.User.Feature.GetProfileMainData;

public class QueryNameEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/QueryName",
            ([FromServices]IMediator mediatr) =>
            {
                return mediatr.Send(new QueryNameQuery());
            })
            .WithDescription("Получает основную информацию о пользователе")
            .RequireAuthorization();
    }
}
