using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using PlaceFeeds.ServiceLayer;
using PlaceFeeds.ServiceLayer.Enums;

namespace PlaceFeeds.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WeatherController : Controller
    {
        public IApiKeyService ApiKeyService { get; set; }

        public WeatherController(IApiKeyService apiKeyService)
        {
            ApiKeyService = apiKeyService;
        }
        
        public async Task<ActionResult> GetWeatherData(float latitude, float longitude)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var apiKey = ApiKeyService.GetApiKey(ApiType.Weather);

                    client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
                    var response = await client.GetAsync($"forecast?lat={latitude}&lon={longitude}&APPID={apiKey}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonConvert.DeserializeObject(stringResult);
                    return Ok(new
                    {
                        WeatherData = weatherData
                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting data from GoogleMaps: {httpRequestException.Message}");
                }
            }
        }

    }
}





