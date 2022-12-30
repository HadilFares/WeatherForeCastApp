using System.ComponentModel.DataAnnotations;

namespace WeatherForeCastApp.Models
{
    public class SearchByCity
    {
        
        //[Required (ErrorMessage ="City Name is empty !!")]
       
        //[StringL(20,MinimumLength =2,ErrorMessage= "Enter a city name greater than 2 and lesser than 20 characters!" )]
        [Display(Name = "City Name")]
        public string CityName{ get; set; }
    }
}
