using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PlaceFeedsServices.ImageService;

namespace PlaceFeeds.Controllers
{
    [Route("[controller]/[action]")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<JsonResult> GetImageData(string placeName, string locationSearchString)
        {
            string jsonString = await _imageService.GetImageData(placeName, locationSearchString);
            return new JsonResult(JsonConvert.DeserializeObject(jsonString));
        }
    }
}





