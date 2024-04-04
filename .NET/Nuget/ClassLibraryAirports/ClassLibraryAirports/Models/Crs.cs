using System.Text.Json.Serialization;

namespace ClassLibraryAirports.Models
{
    public class Crs
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties")]
        public CrsProperties Properties { get; set; }
    }
}
