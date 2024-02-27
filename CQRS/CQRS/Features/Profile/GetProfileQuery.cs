using CQRS.Mediator.Query;

namespace CQRS.Features.Profile;

public record GetProfileQuery(int UserId) : IQuery<int>;