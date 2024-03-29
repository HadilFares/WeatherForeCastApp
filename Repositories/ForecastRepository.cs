﻿using WeatherForeCastApp.OpenWeatherMapModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using WeatherForeCastApp.Models;

namespace WeatherForeCastApp.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        public WeatherResponse GetForecast(string city)
        {
            string App_ID = Constants.Values.OPEN_WEATHER_APP_KEY;
            var client = new HttpClient();
            var weatherURL=$"http://api.openweathermap.org/data/2.5/weather?q={city}&units=Metric&appid={App_ID}";
            try
            {
                var response = client.GetStringAsync(weatherURL).Result;
                System.Diagnostics.Debug.WriteLine(response);
                var content = JsonConvert.DeserializeObject<WeatherResponse>(response);
                return content;
            }
            catch { return null; }
        }

        public WeatherResponse GetForecastPosition(double latitude, double longitude)
        {
            string App_ID = Constants.Values.OPEN_WEATHER_APP_KEY;
            var client = new HttpClient();
            var stringlatitude=latitude.ToString();
            var stringlongitude=longitude.ToString();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?lat={stringlatitude}&lon={stringlongitude}&units=Metric&appid={App_ID}";
            try
            { 
                var response = client.GetStringAsync(weatherURL).Result;
                System.Diagnostics.Debug.WriteLine(response);
                var content = JsonConvert.DeserializeObject<WeatherResponse>(response);
                return content;
            }
            catch { return null; }
        }
    }
}
