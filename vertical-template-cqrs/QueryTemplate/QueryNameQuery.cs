using Messenger.Core.Requests.Abstractions;

namespace NamespaceWillBeInserted.GetProfileMainData;

public record QueryNameQuery(Guid UserId) : IQuery<QueryNameQueryResponse>;