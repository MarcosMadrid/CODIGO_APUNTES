using System.Text.Json.Serialization;

namespace ClassLibraryAirports.Models
{
    public class AirportList
    {
        [JsonPropertyName("value")]
        public List<Airport> Airports { get; set; }
    }
}
