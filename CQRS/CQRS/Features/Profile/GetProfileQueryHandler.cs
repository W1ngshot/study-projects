using CQRS.Mediator.Query;

namespace CQRS.Features.Profile;

public class GetProfileQueryHandler : IQueryHandler<GetProfileQuery, int>
{
    public Task<int> HandleAsync(GetProfileQuery query)
    {
        return Task.FromResult(query.UserId + 1);
    }
}