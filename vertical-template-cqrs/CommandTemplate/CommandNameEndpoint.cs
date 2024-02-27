using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Messenger.Infrastructure.Endpoints;
using Messenger.Infrastructure.Validation.ValidationFilter;

namespace NamespaceWillBeInserted.CommandName;

public class CommandNameEndpoint : IEndpoint
{
    public record CommandNameDto();

    public class DtoValidator : AbstractValidator<CommandNameDto>
    {
        public DtoValidator()
        {
           // Insert your validator
        }
    }

    public void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut(
                "/me",
                async (CommandNameDto dto, IMediator mediator)
                    => Results.Ok(
                        await mediator.Send(
                            new CommandNameCommand())))
            .RequireAuthorization()
            .AddValidation(c => c.AddFor<CommandNameDto>())
            .WithName("CommandName");
    }
}
