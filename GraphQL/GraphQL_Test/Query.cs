namespace GraphQL_Test;

public class Query
{
    [UsePaging]
    [UseSorting]
    public IEnumerable<User> GetUsers()
    {
        return Data.Users;
    }
}