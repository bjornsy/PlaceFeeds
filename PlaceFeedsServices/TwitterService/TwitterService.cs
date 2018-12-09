using PlaceFeedsServices.ApiKeyService;
using PlaceFeedsServices.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Models.DTO;
using Tweetinvi.Parameters;

namespace PlaceFeedsServices.TwitterService
{
    public class TwitterService : ITwitterService
    {
        private readonly IApiKeyService _apiKeyService;

        public TwitterService(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        public async Task<IEnumerable<ITweetDTO>> GetTwitterResults(string placeName, double latitude, double longitude)
        {
            // Set up your credentials
            var appCreds = Auth.SetApplicationOnlyCredentials(_apiKeyService.GetApiKey(ApiType.Twitter), _apiKeyService.GetApiSecret(ApiType.Twitter), true);

            var searchParameter = new SearchTweetsParameters(placeName)
            {
                GeoCode = new GeoCode(latitude, longitude, 3, DistanceMeasure.Miles),
                TweetSearchType = TweetSearchType.OriginalTweetsOnly,
                SearchType = SearchResultType.Recent,
                MaximumNumberOfResults = 30,
                //Until = DateTime.UtcNow
            };

            IEnumerable<ITweet> tweets = await SearchAsync.SearchTweets(searchParameter);

            if (tweets.Count() == 0)
            {
                searchParameter = new SearchTweetsParameters(placeName) //Not limiting by geocode for more results
                {
                    SearchType = SearchResultType.Popular,
                    MaximumNumberOfResults = 30,
                };
                tweets = await SearchAsync.SearchTweets(searchParameter);
            }

            var tweetsDistinctUsers = tweets.GroupBy(t => t.CreatedBy.IdStr).Select(g => g.First());
            return tweetsDistinctUsers.Select(x => x.TweetDTO);
        }
    }
}
