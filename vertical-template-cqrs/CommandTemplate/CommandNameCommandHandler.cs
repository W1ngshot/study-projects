using Messenger.Core.Requests.Abstractions;

namespace NamespaceWillBeInserted.CommandName;

public class CommandNameCommandHandler : ICommandHandler<CommandNameCommand, bool>
{
    private readonly IDbContext _dbContext;

    public CommandNameCommandHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(CommandNameCommand request, CancellationToken cancellationToken)
    {	
		throw new NotImplementedException();
    }
}
