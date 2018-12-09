using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceFeedsServices.LocationService
{
    public interface ILocationService
    {
        Task<string> GetLocationData(string locationName);
    }
}
