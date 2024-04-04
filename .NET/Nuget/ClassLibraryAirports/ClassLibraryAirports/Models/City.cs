using System.Text.Json.Serialization;

namespace ClassLibraryAirports.Models
{
    public class City
    {
        [JsonPropertyName("CountryRegion")]
        public string CountryRegion { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Region")]
        public string Region { get; set; }

    }
}
