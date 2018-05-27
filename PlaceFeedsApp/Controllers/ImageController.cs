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
    public class ImageController : Controller
    {
        public IApiKeyService ApiKeyService { get; set; }

        public ImageController(IApiKeyService apiKeyService)
        {
            ApiKeyService = apiKeyService;
        }

        public async Task<ActionResult> GetImageData(string placeName, string locationSearchString)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var apiKey = ApiKeyService.GetApiKey(ApiType.Image);

                    client.BaseAddress = new Uri("https://api.flickr.com/services/rest/");
                    var response = await client.GetAsync($"?method=flickr.photos.search&api_key={apiKey}&text={placeName}&sort=date-taken-desc{locationSearchString}&format=json&nojsoncallback=1");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var imageData = JsonConvert.DeserializeObject(stringResult);
                    return Ok(new
                    {
                        ImageData = imageData
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





