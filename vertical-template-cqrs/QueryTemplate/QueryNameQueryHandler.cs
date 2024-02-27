using Messenger.Core.Exceptions;
using Messenger.Core.Requests.Abstractions;

namespace NamespaceWillBeInserted.GetProfileMainData;

public class QueryNameQueryHandler : IQueryHandler<QueryNameQuery, QueryNameQueryResponse>
{
    private readonly IDbContext _dbContext;

    public QueryNameQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<QueryNameQueryResponse> Handle(
        QueryNameQuery request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
