
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Text;
using WebApplicationEmpleadosOauth.Models;

namespace ConsoleAppApiEmpleadosHospital.Services
{
    public class ServiceEmpleadosHospital
    {
        private string urlApi;
        private MediaTypeWithQualityHeaderValue mediaType;
        public string? token { get; set; }

        public ServiceEmpleadosHospital(string urlApi)
        {
            this.urlApi = urlApi;
            mediaType = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<string> GetTokenAsync(string user, string pass)
        {
            string request = "/api/Auth/Login";
            LoginModel model = new LoginModel()
            {
                UserName = user,
                Password = pass
            };
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlApi);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Clear();
                string jsonData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await httpClient.PostAsync(request, content);
                if (httpResponse.IsSuccessStatusCode)
                {
                    string data = await httpResponse.Content.ReadAsStringAsync();
                    JObject keys = JObject.Parse(data)!;
                    return keys.GetValue("response")!.ToString();
                }
                else
                {
                    return "Peticion error:" + httpResponse.StatusCode;
                }
            }
        }

        public async Task<string> GetEmpleado(int id)
        {
            string request = "/api/GetEmpleado?id=" + id;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlApi);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage httpResponse = await httpClient.GetAsync(request);
                if (httpResponse.IsSuccessStatusCode)
                {
                    string data = await httpResponse.Content.ReadAsStringAsync();
                    return data;
                }
                else
                {
                    return "Peticion error:" + httpResponse.StatusCode;
                }
            }
        }

    }
}
