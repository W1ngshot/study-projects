public class Data
{
    public List<User> Users = new()
    {
        new User
        {
            Id = 1,
            Nickname = "First",
            Description = "Some Description"
        },
        new User
        {
            Id = 2,
            Nickname = "Second",
            Description = null
        },
        new User
        {
            Id = 3,
            Nickname = "Third",
            Description = null
        }
    };
}

public class User
{
    public int Id { get; set; }
    
    public string Nickname { get; set; }
    
    public string? Description { get; set; }
}