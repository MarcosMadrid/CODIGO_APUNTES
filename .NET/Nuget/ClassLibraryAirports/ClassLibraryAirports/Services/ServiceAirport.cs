using ClassLibraryAirports.Models;
using Newtonsoft.Json;
using System.Net;

namespace ClassLibraryAirports.Services
{
    public class ServiceAirport
    {
        public async Task<AirportList> GetAirportsAsync()
        {
            WebClient obj = new WebClient
            {
                Headers = { ["content-type"] = "application/json" }
            };
            string url = "https://services.odata.org/V4/(S(2esholowikwyef30ogqjzbvf))/TripPinServiceRW/Airports";
            string jsonData = await obj.DownloadStringTaskAsync(url);
            return JsonConvert.DeserializeObject<AirportList>(jsonData);
        }
    }
}
