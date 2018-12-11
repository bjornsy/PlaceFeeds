using Microsoft.Extensions.Configuration;
using PlaceFeedsServices.ApiKeyService;
using PlaceFeedsServices.ImageService;
using PlaceFeedsServices.LocationService;
using Xunit;
using Newtonsoft.Json;
using System.Collections.Generic;
using PlaceFeedsServices.MeetupService;
using PlaceFeedsServices.TwitterService;
using Tweetinvi.Models.DTO;
using PlaceFeedsServices.WeatherService;

namespace PlaceFeedsTests
{
    public class ServiceHttpTests
    {
        private readonly IApiKeyService _apiKeyService;

        public ServiceHttpTests()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<ServiceHttpTests>();
            _apiKeyService = new ApiKeyService(builder.Build());
        }

        [Theory]
        [InlineData("London", null)]
        public async void ImageServiceTest(string placeName, string locationSearchString)
        {
            ImageService imageService = new ImageService(_apiKeyService);

            string response = await imageService.GetImageData(placeName, locationSearchString);
            Dictionary<string, object> jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            string responseStatus = (string)jsonDictionary["stat"];

            Assert.Equal("ok", responseStatus);
        }

        [Theory]
        [InlineData("London")]
        public async void LocationServiceTest(string placeName)
        {
            LocationService LocationService = new LocationService(_apiKeyService);

            string response = await LocationService.GetLocationData(placeName);
            Dictionary<string, object> jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            string responseStatus = (string)jsonDictionary["status"];

            Assert.Equal("OK", responseStatus);
        }

        [Theory]
        [InlineData(51.5073509, -0.1277583)]
        public async void MeetupServiceTest(double latitude, double longitude)
        {
            MeetupService meetupService = new MeetupService(_apiKeyService);

            string response = await meetupService.GetMeetupData(latitude, longitude);
            object[] jsonArray = JsonConvert.DeserializeObject<object[]>(response);

            Assert.NotEmpty(jsonArray);
        }

        [Theory]
        [InlineData("London", 51.5073509, -0.1277583)]
        public async void TwitterServiceTest(string placeName, double latitude, double longitude)
        {
            TwitterService twitterService = new TwitterService(_apiKeyService);

            IEnumerable<ITweetDTO> response = await twitterService.GetTwitterResults(placeName, latitude, longitude);

            Assert.NotEmpty(response);
        }

        [Theory]
        [InlineData(51.5073509, -0.1277583)]
        public async void WeatherServiceTest(double latitude, double longitude)
        {
            WeatherService weatherService = new WeatherService(_apiKeyService);

            string response = await weatherService.GetWeatherData(latitude, longitude);
            Dictionary<string, object> jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
            string responseStatus = (string)jsonDictionary["cod"];

            Assert.Equal("200", responseStatus);
        }

    }
}
