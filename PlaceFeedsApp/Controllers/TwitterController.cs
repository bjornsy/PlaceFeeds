using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tweetinvi.Models.DTO;
using Newtonsoft.Json;
using PlaceFeedsServices.TwitterService;

namespace PlaceFeeds.Controllers
{
    [Route("[controller]")]
    public class TwitterController : Controller
    {

        private readonly ITwitterService _twitterService;

        public TwitterController(ITwitterService twitterService)
        {
            _twitterService = twitterService;
        }

        [HttpGet]
        public async Task<JsonResult> GetTwitterResults(string placeName, double latitude, double longitude)
        {
            IEnumerable<ITweetDTO> tweetResults = await _twitterService.GetTwitterResults(placeName, latitude, longitude);
            return new JsonResult(JsonConvert.SerializeObject(tweetResults));
        }

    }   
}





