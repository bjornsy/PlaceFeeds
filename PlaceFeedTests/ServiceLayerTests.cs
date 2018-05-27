using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaceFeeds.ServiceLayer;
using PlaceFeeds.ServiceLayer.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PlaceFeedTests
{
    [TestClass]
    public class ServiceLayerTests
    {
        private IApiKeyService _apiKeyService = new ApiKeyService();
        private List<ApiKey> _apiKeys = ApiKeys.apiKeys;

        [TestMethod]
        public void GetLocationApiKeyString()
        {
            string key;
            ApiKey apiKey;

            key = _apiKeyService.GetApiKey(ApiType.Location);
            apiKey = _apiKeys.First(k => k.Key == key);

            Assert.AreEqual(key, apiKey.Key);
        }

        [TestMethod]
        public void GetWeatherApiKeyString()
        {
            string key;
            ApiKey apiKey;

            key = _apiKeyService.GetApiKey(ApiType.Weather);
            apiKey = _apiKeys.First(k => k.Key == key);

            Assert.AreEqual(key, apiKey.Key);
        }

        [TestMethod]
        public void GetImageApiKeyString()
        {
            string key;
            ApiKey apiKey;

            key = _apiKeyService.GetApiKey(ApiType.Image);
            apiKey = _apiKeys.First(k => k.Key == key);

            Assert.AreEqual(key, apiKey.Key);
        }

        [TestMethod]
        public void GetTwitterApiKeyString()
        {
            string key;
            ApiKey apiKey;

            key = _apiKeyService.GetApiKey(ApiType.Twitter);
            apiKey = _apiKeys.First(k => k.Key == key);

            Assert.AreEqual(key, apiKey.Key);
        }

        [TestMethod]
        public void GetMeetupApiKeyString()
        {
            string key;
            ApiKey apiKey;

            key = _apiKeyService.GetApiKey(ApiType.Meetup);
            apiKey = _apiKeys.First(k => k.Key == key);

            Assert.AreEqual(key, apiKey.Key);
        }

        [TestMethod]
        public void GetLocationSecret()
        {
            string secret;
            ApiKey apiKey;

            secret = _apiKeyService.GetApiSecret(ApiType.Location);
            apiKey = _apiKeys.First(k => k.Secret == secret);

            Assert.AreEqual(secret, apiKey.Secret);
        }

        [TestMethod]
        public void GetTwitterSecret()
        {
            string secret;
            ApiKey apiKey;

            secret = _apiKeyService.GetApiSecret(ApiType.Twitter);
            apiKey = _apiKeys.First(k => k.Secret == secret);

            Assert.AreEqual(secret, apiKey.Secret);
        }
    }
}
