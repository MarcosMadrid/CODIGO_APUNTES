using System.Text.Json.Serialization;

namespace ClassLibraryAirports.Models
{
    public class Location
    {
        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("Loc")]
        public Localidad Localidad { get; set; }

    }
}
