using AdventureLog_API.Models;

namespace AdventureLog_API.Database;

public interface IEfCoreService
{
    Task<TEntity?> FetchAsync<TEntity, TId>(TId id)
        where TEntity : class, IEntity<TId>;
}

public class EfCoreService : IEfCoreService
{
    private ApplicationContext _context { get; init; }

    public EfCoreService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> FetchAsync<TEntity, TId>(TId id)
        where TEntity : class, IEntity<TId> => await _context.FindAsync<TEntity>(id);
}
