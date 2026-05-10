using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IReadOnlyList<WeatherForecastViewModel> Forecasts { get; private set; } = Array.Empty<WeatherForecastViewModel>();

    public async Task OnGetAsync()
    {
        var client = _httpClientFactory.CreateClient("Backend");
        using var response = await client.GetAsync("GetWeatherForecast");
        response.EnsureSuccessStatusCode();

        var forecasts = await response.Content.ReadFromJsonAsync<List<WeatherForecastViewModel>>();
        Forecasts = forecasts ?? new List<WeatherForecastViewModel>();
    }
}

public class WeatherForecastViewModel
{
    public string? DateFormatted { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string? Summary { get; set; }

    public string? Description { get; set; }
}
