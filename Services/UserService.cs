using AdventureLog_API.Models;
using AdventureLog_API.Repositories;

namespace AdventureLog_API.Services;

public interface IUserService
{
    Task<User> GetSampleUserAsync(Guid userId);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetSampleUserAsync(Guid userId)
    {
        var user = await _userRepository.GetSampleUserAsync(userId);

        return user;
    }
}
