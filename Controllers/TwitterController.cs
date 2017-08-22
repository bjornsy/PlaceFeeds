using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using Newtonsoft.Json;
using PlaceFeeds.ServiceLayer;
using PlaceFeeds.ServiceLayer.Enums;

namespace PlaceFeeds.Controllers
{
    [Route("api/[controller]")]
    public class TwitterController : Controller
    {

        public IApiKeyService ApiKeyService { get; set; }

        public TwitterController(IApiKeyService apiKeyService)
        {
            ApiKeyService = apiKeyService;
        }


        [HttpGet("[action]")]
        public JsonResult GetTwitterResults(string placeName, double latitude, double longitude)
        {

            // Set up your credentials
            var appCreds = Auth.SetApplicationOnlyCredentials(ApiKeyService.GetApiKey(ApiType.Twitter), ApiKeyService.GetApiSecret(ApiType.Twitter), true);

            var searchParameter = new SearchTweetsParameters(placeName)
            {
                GeoCode = new GeoCode(latitude, longitude, 3, DistanceMeasure.Miles),
                TweetSearchType = TweetSearchType.OriginalTweetsOnly,
                SearchType = SearchResultType.Recent,
                MaximumNumberOfResults = 30,
                //Until = DateTime.UtcNow
            };

            var tweets = Search.SearchTweets(searchParameter);          

            if (tweets.Count() == 0)
            {
                searchParameter = new SearchTweetsParameters(placeName) //Not limiting by geocode for more results
                {
                    SearchType = SearchResultType.Popular,
                    MaximumNumberOfResults = 30,
                };
                tweets = Search.SearchTweets(searchParameter);
            }

            var tweetsDistinctUsers = tweets.GroupBy(t => t.CreatedBy.IdStr).Select(g => g.First());
            var tweetsDTO = tweetsDistinctUsers.Select(x => x.TweetDTO);

            return Json(tweetsDTO); 
        }


    }

    
}





