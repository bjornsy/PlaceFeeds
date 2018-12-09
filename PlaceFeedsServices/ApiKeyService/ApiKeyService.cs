using Microsoft.Extensions.Configuration;
using PlaceFeedsServices.Enums;

namespace PlaceFeedsServices.ApiKeyService
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

