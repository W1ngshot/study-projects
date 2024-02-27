using CQRS.Mediator.Command;

namespace CQRS.Features.SetProfileId;

public record SetProfileCommand(int UserId) : ICommand;