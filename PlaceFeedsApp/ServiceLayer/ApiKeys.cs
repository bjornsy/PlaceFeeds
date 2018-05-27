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
           new ApiKey { Type = ApiType.Location, Key = "KEY", Secret = "SECRET"},
           new ApiKey { Type = ApiType.Weather, Key = "KEY"},
           new ApiKey { Type = ApiType.Image, Key = "KEY"},
           new ApiKey { Type = ApiType.Twitter, Key = "KEY", Secret = "SECRET"},
           new ApiKey { Type = ApiType.Meetup, Key = "KEY"}
        };
    }
}
