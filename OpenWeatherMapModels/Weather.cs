namespace WeatherForeCastApp.OpenWeatherMapModels
{
    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public string ImagePath
        {
            get
            {
                return $"http://openweathermap.org/img/wn/{Icon}@1x.png";
            }
        }
    }
}
