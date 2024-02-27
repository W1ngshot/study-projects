using CQRS.Mediator.Command;

namespace CQRS.Features.SetProfileId;

public class SetProfileCommandHandler : ICommandHandler<SetProfileCommand>
{
    public async Task HandleAsync(SetProfileCommand command)
    {
        Thread.Sleep(1000);
    }
}