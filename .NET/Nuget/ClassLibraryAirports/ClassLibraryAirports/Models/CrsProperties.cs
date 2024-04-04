using System.Text.Json.Serialization;

namespace ClassLibraryAirports.Models
{
    public class CrsProperties
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
