namespace CookieApi.Models;

public class User : BaseEntity
{
    public required string Nickname { get; set; }
    
    public required string PasswordHash { get; set; }
    
    public required string PasswordSalt { get; set; }
    
    public required string Role { get; set; }
}