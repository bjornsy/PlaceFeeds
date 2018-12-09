using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlaceFeedsServices.LocationService;

namespace PlaceFeeds.Controllers
{
    [Route("[controller]/[action]")]
    public class LocationSearchController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationSearchController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("{locationName}")]
        public async Task<JsonResult> GetLocationData(string locationName)
        {
            string jsonString = await _locationService.GetLocationData(locationName);
            return new JsonResult(JsonConvert.DeserializeObject(jsonString));
        }

    }
}





