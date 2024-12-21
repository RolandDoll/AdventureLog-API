using AdventureLog_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdventureLog_API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<User> Get()
    {
        return new User();
    }
}
