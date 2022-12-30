using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
           
                //viewModel.Temp = (int)((weatherResponse.Main.Temp -32)/1.8);
                viewModel.Temp= (float)weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
                viewModel.Icon = weatherResponse.Weather[0].Icon;
               
                
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Position(double latitude, double longitude)
        {
           
            Console.WriteLine(longitude);
            System.Diagnostics.Debug.WriteLine(latitude); 
            System.Diagnostics.Debug.WriteLine(longitude);
               
            WeatherResponse weatherResponse = _forecastRepository.GetForecastPosition(latitude, longitude);
            City viewModel = new City();
            //System.Diagnostics.Debug.WriteLine();
            if (weatherResponse != null)
            {
               
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;

                //viewModel.Temp = (int)((weatherResponse.Main.Temp -32)/1.8);
                viewModel.Temp =  (float)weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
                viewModel.Icon = weatherResponse.Weather[0].Icon;
               
                
            }
           
            return View("City",viewModel);
        }
    }
}
