using PlaceFeedsServices.ApiKeyService;
using PlaceFeedsServices.Enums;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaceFeedsServices.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly IApiKeyService _apiKeyService;

        public WeatherService(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        public async Task<string> GetWeatherData(float latitude, float longitude)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiKey = _apiKeyService.GetApiKey(ApiType.Weather);

                client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
                var response = await client.GetAsync($"forecast?lat={latitude}&lon={longitude}&APPID={apiKey}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }

    }
}
