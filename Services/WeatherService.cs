using Trabajo_9_5_26.Helpers;
using Trabajo_9_5_26.Models;
using Trabajo_9_5_26.Repositories; // <-- Faltaba este using

namespace Trabajo_9_5_26.Services
{
    public interface IWeatherService
    {
        // Quitamos el (int days) porque ya no lo necesitamos
        IEnumerable<WeatherForecastViewModel> GetProcessedForecasts();
    }

    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;

        public WeatherService(IWeatherRepository repository)
        {
            _repository = repository;
        }

        // Quitamos el (int days) aquí también
        public IEnumerable<WeatherForecastViewModel> GetProcessedForecasts()
        {
            // Llamamos al repositorio SIN el parámetro days
            var rawData = _repository.GetForecasts();

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