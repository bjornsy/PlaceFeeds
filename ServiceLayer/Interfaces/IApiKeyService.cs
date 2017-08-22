using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaceFeeds.ServiceLayer.Enums;

namespace PlaceFeeds.ServiceLayer
{
    public interface IApiKeyService
    {
        string GetApiKey(ApiType apiType);
        string GetApiSecret(ApiType apiType);
    }
}
