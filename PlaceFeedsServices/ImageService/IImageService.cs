using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceFeedsServices.ImageService
{
    public interface IImageService
    {
        Task<string> GetImageData(string placeName, string locationSearchString);
    }
}
