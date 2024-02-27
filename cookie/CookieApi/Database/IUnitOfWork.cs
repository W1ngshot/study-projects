namespace CookieApi.Database;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}