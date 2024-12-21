using AdventureLog_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdventureLog_API.Controllers;

[ApiController]
[Route("sample")]
public class SampleController : ControllerBase
{
    private readonly ApplicationConfig _config;

    public SampleController(ApplicationConfig config)
    {
        _config = config;
    }

    [HttpGet("test")]
    public async Task<User> Get()
    {
        var test = new User()
        {
            Id = Guid.NewGuid(),
            Username = "radoll",
            Password = _config.ConnectionString,
            DisplayName = "Roland Doll"
        };

        return test;
    }
}
