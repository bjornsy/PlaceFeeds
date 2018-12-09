using System.Threading.Tasks;

namespace PlaceFeedsServices.MeetupService
{
    public interface IMeetupService
    {
        Task<string> GetMeetupData(double latitude, double longitude);
    }
}
