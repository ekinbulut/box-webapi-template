using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace box_webapi_template.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastControllerV2 : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastControllerV2(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

   
    [Authorize]
    [HttpGet(Name = "v2/GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}