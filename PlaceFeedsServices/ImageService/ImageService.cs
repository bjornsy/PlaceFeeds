using PlaceFeedsServices.ApiKeyService;
using PlaceFeedsServices.Enums;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaceFeedsServices.ImageService
{
    public class ImageService : IImageService
    {
        private readonly IApiKeyService _apiKeyService;

        public ImageService(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        public async Task<string> GetImageData(string placeName, string locationSearchString)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiKey = _apiKeyService.GetApiKey(ApiType.Image);

                client.BaseAddress = new Uri("https://api.flickr.com/services/rest/");
                var response = await client.GetAsync($"?method=flickr.photos.search&api_key={apiKey}&text={placeName}&sort=date-taken-desc{locationSearchString}&format=json&nojsoncallback=1");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
