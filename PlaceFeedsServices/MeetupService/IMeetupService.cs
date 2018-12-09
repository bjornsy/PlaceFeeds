using System.Threading.Tasks;

namespace PlaceFeedsServices.MeetupService
{
    public interface IMeetupService
    {
        Task<string> GetMeetupData(float latitude, float longitude);
    }
}
