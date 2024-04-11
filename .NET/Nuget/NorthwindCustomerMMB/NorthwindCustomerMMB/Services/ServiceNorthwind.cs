using Newtonsoft.Json;
using NorthwindCustomerMMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace NorthwindCustomerMMB.Services
{
    public class ServiceNorthwind
    {
        public async Task<ListCustomers> GetCustomersAsync()
        {
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            string url = "https://northwind.netcore.io/customers.json";
            string dataJson = await client.DownloadStringTaskAsync(url);
            ListCustomers customers = JsonConvert.DeserializeObject<ListCustomers>(dataJson);

            return customers;
        }
    }
}
