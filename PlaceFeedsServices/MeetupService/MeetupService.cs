using PlaceFeedsServices.ApiKeyService;
using PlaceFeedsServices.Enums;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaceFeedsServices.MeetupService
{
    public class MeetupService : IMeetupService
    {
        private readonly IApiKeyService _apiKeyService;

        public MeetupService(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        public async Task<string> GetMeetupData(double latitude, double longitude)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiKey = _apiKeyService.GetApiKey(ApiType.Meetup);

                client.BaseAddress = new Uri("https://api.meetup.com/find/");
                var response = await client.GetAsync($"events?key={apiKey}&sign=true&photo-host=public&lon={longitude}&radius=smart&lat={latitude}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
