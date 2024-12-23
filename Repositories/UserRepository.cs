using AdventureLog_API.Database;
using AdventureLog_API.Models;

namespace AdventureLog_API.Repositories;

public interface IUserRepository
{
    Task<User> GetSampleUserAsync(Guid userId);
}

public class UserRepository : IUserRepository
{
    private readonly IEfCoreService _efCoreService;

    public UserRepository(IEfCoreService efCoreService)
    {
        _efCoreService = efCoreService;
    }

    public async Task<User> GetSampleUserAsync(Guid userId)
    {
        var user = await _efCoreService.FetchAsync<User, Guid>(
            userId
        );

        return user;
    }
}