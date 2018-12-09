using PlaceFeedsServices.Enums;

namespace PlaceFeedsServices.ApiKeyService
{
    public interface IApiKeyService
    {
        string GetApiKey(ApiType apiType);
        string GetApiSecret(ApiType apiType);
    }
}
