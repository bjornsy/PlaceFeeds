using Microsoft.Extensions.Configuration;
using PlaceFeedsServices.ApiKeyService;
using PlaceFeedsServices.Enums;
using Xunit;

namespace PlaceFeedsTests
{
    public class ApiKeyServiceTests
    {
        private readonly IConfiguration _configuration;

        public ApiKeyServiceTests()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<ApiKeyServiceTests>();
            _configuration = builder.Build();              
        }

        [Theory]
        [InlineData(ApiType.Location)]
        [InlineData(ApiType.Weather)]
        [InlineData(ApiType.Image)]
        [InlineData(ApiType.Twitter)]
        [InlineData(ApiType.Meetup)]
        public void GetApiKeyTests(ApiType apiType)
        {
            ApiKeyService apiKeyService = new ApiKeyService(_configuration);

            string key = apiKeyService.GetApiKey(apiType);

            Assert.False(string.IsNullOrEmpty(key));
        }

        [Theory]
        [InlineData(ApiType.Location)]
        [InlineData(ApiType.Twitter)]
        public void GetApiSecretTests(ApiType apiType)
        {
            ApiKeyService apiKeyService = new ApiKeyService(_configuration);

            string key = apiKeyService.GetApiSecret(apiType);

            Assert.False(string.IsNullOrEmpty(key));
        }
    }
}
