using Microsoft.AspNetCore.Mvc;
using Trabajo_9_5_26.Models;
using Trabajo_9_5_26.Services;

namespace Trabajo_9_5_26.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EjecucionController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public EjecucionController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("/GetWeatherForecast", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecastViewModel> Get()
        {
            // Quitamos el 5 de adentro de los paréntesis
            return _weatherService.GetProcessedForecasts();
        }
    }
}