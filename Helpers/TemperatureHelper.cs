namespace Trabajo_9_5_26.Helpers
{
    public static class TemperatureHelper
    {
        public static string GetDescription(int tempC)
        {
            return tempC switch
            {
                < 0 => "Freezing cold",
                >= 0 and < 15 => "Chilly weather",
                >= 15 and < 25 => "Nice and mild",
                >= 25 and < 35 => "Warm day",
                _ => "Scorching hot!"
            };
        }
    }
}
