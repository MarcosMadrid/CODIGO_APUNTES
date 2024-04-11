using Newtonsoft.Json;

namespace NorthwindCustomerMMB.Models
{
    public class ListCustomers
    {
        [JsonProperty("results")]
        public List<Customer> Customers { get; set; }
    }
}
