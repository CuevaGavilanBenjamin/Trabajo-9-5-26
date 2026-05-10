using Npgsql;
using Trabajo_9_5_26.Models;

namespace Trabajo_9_5_26.Repositories // <-- Faltaba el namespace
{
    // <-- AQUÍ ESTÁ LA INTERFAZ QUE FALTABA
    public interface IWeatherRepository
    {
        IEnumerable<WeatherForecast> GetForecasts();
    }

    public class WeatherRepository : IWeatherRepository
    {
        private readonly NpgsqlConnection _connection;

        public WeatherRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<WeatherForecast> GetForecasts()
        {
            var forecasts = new List<WeatherForecast>();

            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }

            string sql = "SELECT date, temperature_c, summary FROM weather_forecasts";

            using (var command = new NpgsqlCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        forecasts.Add(new WeatherForecast
                        {
                            Date = DateOnly.FromDateTime(reader.GetDateTime(0)),
                            TemperatureC = reader.GetInt32(1),
                            Summary = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty
                        });
                    }
                }
            }

            return forecasts;
        }
    }
}