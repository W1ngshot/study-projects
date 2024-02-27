using CQRS.Features.SetProfileId;

namespace CQRS.SecurityHandlers;

public class SetProfileSecurityHandler : ISecurityHandler<SetProfileCommand>
{
    public async Task<string?> HandleAsync(SetProfileCommand command)
    {
        return command.UserId == 1 ? "kuda menyat' admina, zapresheno" : null;
    }
}