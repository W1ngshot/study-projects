namespace SpecAndMapper;

public static class UserSpec
{
    public static Specification<User> PublicUser = new(user => user.Role == "Admin");
}