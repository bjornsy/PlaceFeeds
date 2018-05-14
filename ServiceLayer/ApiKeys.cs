using PlaceFeeds.ServiceLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceFeeds.ServiceLayer
{
    public class ApiKeys
    {
        public static List<ApiKey> apiKeys = new List<ApiKey> {
           new ApiKey { Type = ApiType.Location, Key = "API_KEY_HERE", Secret = "SECRET_HERE"},
           new ApiKey { Type = ApiType.Weather, Key = "API_KEY_HERE"},
           new ApiKey { Type = ApiType.Image, Key = "API_KEY_HERE"},
           new ApiKey { Type = ApiType.Twitter, Key = "API_KEY_HERE", Secret = "SECRET_HERE"},
           new ApiKey { Type = ApiType.Meetup, Key = "API_KEY_HERE"}
        };
    }
}
