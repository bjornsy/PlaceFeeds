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
    public class LocationSearchController : Controller
    {
        public IApiKeyService ApiKeyService { get; set; }

        public LocationSearchController(IApiKeyService apiKeyService)
        {
            ApiKeyService = apiKeyService;
        }

        [HttpGet("{locationName}")]
        public async Task<ActionResult> GetLocationData(string locationName)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var apiKey = ApiKeyService.GetApiKey(ApiType.Location);

                    client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/geocode/");
                    var response = await client.GetAsync($"json?address={locationName}&key={apiKey}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var locationData = JsonConvert.DeserializeObject(stringResult);
                    return Ok(new
                    {
                        LocationData = locationData
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





