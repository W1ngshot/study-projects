using HotChocolate.Subscriptions;

namespace GraphQL_Test;

public class Mutation
{
    public async Task<Item> AddItem(ITopicEventSender sender, string userName, Item item)
    {
        Data.Users.FirstOrDefault(x => x.Name == userName)?.Items.Add(item);
        await sender.SendAsync(nameof(Subscription.OnItemAdded), item);

        return item;
    }
}