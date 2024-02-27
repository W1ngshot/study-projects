using CookieApi.Database;
using CookieApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CookieApi.Repositories;

public class UserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetUserByIdAsync(Guid id) => 
        await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    
    public async Task<User?> GetUserByNicknameAsync(string nickname) => 
        await _dbContext.Users.FirstOrDefaultAsync(user => user.Nickname == nickname);

    public async Task<IEnumerable<User>> GetAllUsersAsync() =>
        await _dbContext.Users.AsNoTracking().ToListAsync();

    public async Task AddUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}