using Microsoft.AspNetCore.Mvc;
using WeatherForeCastApp.Models;
using WeatherForeCastApp.OpenWeatherMapModels;
using WeatherForeCastApp.Repositories;

namespace WeatherForeCastApp.Controllers
{
    public class WeatherForeCastController : Controller
    {
        private readonly IForecastRepository _forecastRepository;
        public WeatherForeCastController(IForecastRepository forecastRepository)
        {
            _forecastRepository = forecastRepository;
        }

      
        public IActionResult SearchByCity ()
        {
            var viewModel = new SearchByCity();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {
            
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForeCast", new { city = model.CityName });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _forecastRepository.GetForecast(city);
            City viewModel = new City();

            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
           
                viewModel.Temp = (int)((weatherResponse.Main.Temp -32)/1.8);
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
                viewModel.Icon = weatherResponse.Weather[0].Icon;
               
                
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Position(Position data)
        {
            double latitude = data.latitude;
            double longitude  = data.longitude;
            
            
            WeatherResponse weatherResponse = _forecastRepository.GetForecastPosition(latitude, longitude);
            City viewModel = new City();

            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
           
                viewModel.Temp = (int)((weatherResponse.Main.Temp -32)/1.8);
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
                viewModel.Icon = weatherResponse.Weather[0].Icon;
               
                
            }
            return View("City",viewModel);
        }
    }
}
