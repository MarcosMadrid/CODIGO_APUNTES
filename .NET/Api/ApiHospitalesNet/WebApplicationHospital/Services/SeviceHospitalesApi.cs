using ApiHospitalesNet.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;

namespace WebApplicationHospital.Services
{
    public class SeviceHospitalesApi
    {
        public readonly string domainHospitalApi;
        private MediaTypeWithQualityHeaderValue header;

        public SeviceHospitalesApi(IConfiguration configuration)
        {
            domainHospitalApi = configuration.GetValue<string>("ServiceUrlHospitalApi")!;
            header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Hospital>> GetHospitales()
        {
            string query = "api/Hospitales";
            string fullUrl = domainHospitalApi + query;
            #region HttpWebRequest Metodo
            //WebRequest request = WebRequest.Create(fullUrl);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream dataStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(dataStream);
            //string response = reader.ReadToEnd();
            //List<Hospital> hospitales = JsonConvert.DeserializeObject<List<Hospital>>(response)!;
            #endregion

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(domainHospitalApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage response = await client.GetAsync(fullUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Hospital> hospitales = JsonConvert.DeserializeObject<List<Hospital>>(json)!;
                    return hospitales;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Hospital> GetHospital(int id)
        {
            string query = "api/Hospitales/" + id;
            string fullUrl = domainHospitalApi + query;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(domainHospitalApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage response = await client.GetAsync(fullUrl);
                if (response.IsSuccessStatusCode)
                {
                    Hospital hospital = await response.Content.ReadAsAsync<Hospital>();
                    return hospital;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
