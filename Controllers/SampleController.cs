using AdventureLog_API.Models;
using AdventureLog_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureLog_API.Controllers;

[ApiController]
[Route("sample")]
public class SampleController : ControllerBase
{
    private readonly IUserService _userService;

    public SampleController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}")]
    public async Task<User> Get(Guid userId)
    {
        var test = await _userService.GetSampleUserAsync(userId);

        return test;
    }
}
