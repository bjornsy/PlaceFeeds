using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlaceFeedsServices.WeatherService;

namespace PlaceFeeds.Controllers
{
    [Route("[controller]/[action]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<JsonResult> GetWeatherData(float latitude, float longitude)
        {
            string jsonString = await _weatherService.GetWeatherData(latitude, longitude);
            return new JsonResult(JsonConvert.DeserializeObject(jsonString));
        }
    }
}





