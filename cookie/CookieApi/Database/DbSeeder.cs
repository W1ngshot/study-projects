using CookieApi.HelperServices;
using CookieApi.Models;

namespace CookieApi.Database;

public class DbSeeder
{
    private readonly CryptographyService _cryptography;

    public DbSeeder(CryptographyService cryptography)
    {
        _cryptography = cryptography;
    }

    public IEnumerable<User> GetDefaultUsersForDb()
    {
        //login defaultUser
        //password userPass

        var userSalt = _cryptography.GenerateSalt();
        var userPass = _cryptography.EncryptPasswordAsync("userPass", userSalt);

        var user = new User
        {
            Nickname = "defaultUser",
            PasswordHash = userPass,
            PasswordSalt = userSalt,
            Role = "user"
        };
        
        // login defaultAdmin
        //password adminPass

        var adminSalt = _cryptography.GenerateSalt();
        var adminPass = _cryptography.EncryptPasswordAsync("adminPass", adminSalt);

        var admin = new User
        {
            Nickname = "defaultAdmin",
            PasswordHash = adminPass,
            PasswordSalt = adminSalt,
            Role = "admin"
        };

        return new[] {user, admin};
    }
}