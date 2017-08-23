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
    public class MeetupController : Controller
    {
        public IApiKeyService ApiKeyService { get; set; }

        public MeetupController(IApiKeyService apiKeyService)
        {
            ApiKeyService = apiKeyService;
        }

        //https://www.meetup.com/meetup_api/docs/find/events/

        public async Task<ActionResult> GetMeetupData(float latitude, float longitude)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var apiKey = ApiKeyService.GetApiKey(ApiType.Meetup);

                    client.BaseAddress = new Uri("https://api.meetup.com/find/");
                    var response = await client.GetAsync($"events?key={apiKey}&sign=true&photo-host=public&lon={longitude}&radius=smart&lat={latitude}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var meetupData = JsonConvert.DeserializeObject(stringResult);
                    return Ok(new
                    {
                        MeetupData = meetupData
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





