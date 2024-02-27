namespace GraphQL_Test;

public static class Data
{
    public static List<User> Users = new List<User>()
    {
        new User()
        {
            Name = "bcd",
            Items = new List<Item>()
            {
                new Item()
                {
                    Name = "first"
                },
                new Item()
                {
                    Name = "second"
                }
            }
        },
        new User()
        {
            Name = "abc",
            Items = new List<Item>()
            {
                new Item()
                {
                    Name = "one"
                }
            }
        }
    };
}