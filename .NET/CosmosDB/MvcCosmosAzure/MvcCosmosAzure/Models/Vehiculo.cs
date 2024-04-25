using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MvcCosmosAzure.Models
{
    public class Vehiculo
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public string? Imagen { get; set; }

        public Motor? Motor { get; set; }
    }
}
