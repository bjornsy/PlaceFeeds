using Microsoft.Extensions.Configuration;
using PlaceFeeds.ServiceLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceFeeds.ServiceLayer
{
    public class ApiKeyService: IApiKeyService
    {
        private readonly IConfiguration Configuration;

        public ApiKeyService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetApiKey(ApiType apiType)
        {
            return Configuration[apiType.ToString()+":ApiKey"];
        }

        public string GetApiSecret(ApiType apiType)
        {
            return Configuration[apiType.ToString() + ":Secret"];
        }
    
    }
}

