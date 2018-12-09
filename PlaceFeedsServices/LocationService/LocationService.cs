using PlaceFeedsServices.ApiKeyService;
using PlaceFeedsServices.Enums;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaceFeedsServices.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly IApiKeyService _apiKeyService;

        public LocationService(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        public async Task<string> GetLocationData(string locationName)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiKey = _apiKeyService.GetApiKey(ApiType.Location);

                client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/geocode/");
                var response = await client.GetAsync($"json?address={locationName}&key={apiKey}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
