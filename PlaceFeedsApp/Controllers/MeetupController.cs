using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlaceFeedsServices.MeetupService;

namespace PlaceFeeds.Controllers
{
    [Route("[controller]/[action]")]
    public class MeetupController : Controller
    {
        private readonly IMeetupService _meetupService;

        public MeetupController(IMeetupService meetupService)
        {
            _meetupService = meetupService;
        }

        public async Task<JsonResult> GetMeetupData(float latitude, float longitude)
        {
            string jsonString = await _meetupService.GetMeetupData(latitude, longitude);
            return new JsonResult(JsonConvert.DeserializeObject(jsonString));
        }
    }
}





