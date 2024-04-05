using ApiHospitalesNet.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;

namespace WebApplicationHospital.Services
{
    public class SeviceHospitalesApi
    {
        public readonly string domainHospitalApi;

        public SeviceHospitalesApi(IConfiguration configuration)
        {
            domainHospitalApi = configuration.GetValue<string>("ServiceUrlHospitalApi")!;
        }

        public async Task<List<Hospital>> GetHospitales()
        {
            string query = "api/Hospitales";
            string fullUrl = domainHospitalApi + query;
            WebRequest request = WebRequest.Create(fullUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            List<Hospital> hospitales = JsonConvert.DeserializeObject<List<Hospital>>(responseFromServer)!;
            return hospitales;
        }

        public async Task<Hospital> GetHospital(int id)
        {
            string query = "api/Hospitales/" + id;
            string fullUrl = domainHospitalApi + query;
            WebRequest request = WebRequest.Create(fullUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            Hospital hospital = JsonConvert.DeserializeObject<Hospital>(responseFromServer)!;
            return hospital;
        }
    }
}
