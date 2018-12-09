using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models.DTO;

namespace PlaceFeedsServices.TwitterService
{
    public interface ITwitterService
    {
        Task<IEnumerable<ITweetDTO>> GetTwitterResults(string placeName, double latitude, double longitude);
    }
}
