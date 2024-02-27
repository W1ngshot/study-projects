namespace GraphQL_Test;

public class Subscription
{
    [Subscribe]
    public Item OnItemAdded([EventMessage] Item item) => item;
}