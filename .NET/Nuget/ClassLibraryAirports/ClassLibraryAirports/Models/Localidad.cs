using System.Text.Json.Serialization;

namespace ClassLibraryAirports.Models
{
    public class Localidad
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public double[] Coordinates { get; set; }

        [JsonPropertyName("crs")]
        public Crs Crs { get; set; }
    }
}
