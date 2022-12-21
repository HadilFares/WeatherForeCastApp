using WeatherForeCastApp.OpenWeatherMapModels;

namespace WeatherForeCastApp.Repositories
{
    public interface IForecastRepository
    {
        WeatherResponse GetForecast(string city);
    }
}
