using Trabajo_9_5_26.Helpers;
using Trabajo_9_5_26.Models;
using Trabajo_9_5_26.Repositories;

namespace Trabajo_9_5_26.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecastViewModel> GetProcessedForecasts(int days);
    }

    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;

        public WeatherService(IWeatherRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<WeatherForecastViewModel> GetProcessedForecasts(int days)
        {
            var rawData = _repository.GetForecasts(days);

            return rawData.Select(f => new WeatherForecastViewModel
            {
                DateFormatted = f.Date.ToString("yyyy-MM-dd"),
                TemperatureC = f.TemperatureC,
                TemperatureF = f.TemperatureF,
                Summary = f.Summary ?? "N/A",
                Description = TemperatureHelper.GetDescription(f.TemperatureC)
            });
        }
    }
}
