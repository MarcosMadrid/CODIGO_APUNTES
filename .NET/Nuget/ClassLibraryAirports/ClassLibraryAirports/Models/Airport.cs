using System.Text.Json.Serialization;

namespace ClassLibraryAirports.Models
{
    public class Airport
    {
        [JsonPropertyName("IcaoCode")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("IataCode")]
        public string IataCode { get; set; }

        [JsonPropertyName("Location")]
        public Location Location { get; set; }
    }
}

