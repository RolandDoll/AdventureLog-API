using AdventureLog_API.Database;
using AdventureLog_API.Models;

namespace AdventureLog_API.Repositories;

public interface IUserRepository
{
    Task<User> GetSampleUserAsync();
}

public class UserRepository : IUserRepository
{
    private readonly IEfCoreService _efCoreService;

    public UserRepository(IEfCoreService efCoreService)
    {
        _efCoreService = efCoreService;
    }

    public async Task<User> GetSampleUserAsync()
    {
        var user = await _efCoreService.FetchAsync<User, Guid>(
            Guid.Parse("84f82624-94a7-43d6-86d5-9b98e8fee1ac")
        );

        return user;
    }
}