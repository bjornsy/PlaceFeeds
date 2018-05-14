using PlaceFeeds.ServiceLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceFeeds.ServiceLayer
{
    public class ApiKeyService: IApiKeyService
    {
        List<ApiKey> apiKeys = ApiKeys.apiKeys;

        public string GetApiKey(ApiType apiType)
        {
            var key = (apiKeys.FirstOrDefault(a => a.Type == apiType)).Key;
            return key;
        }

        public string GetApiSecret(ApiType apiType)
        {
            return (apiKeys.FirstOrDefault(a => a.Type == apiType)).Secret;
        }
    
    }

    public class ApiKey
    {
        public ApiType Type { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
    }
}

