using WeatherForeCastApp.OpenWeatherMapModels;

namespace WeatherForeCastApp.Repositories
{
    public interface IForecastRepository
    {
        WeatherResponse GetForecast(string city);
        WeatherResponse GetForecastPosition(double latitude, double longitude);
        
    }
}
