using ApiCrudCoreDoctores.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MvcCoreCliente.Services
{
    public class ServiceDoctores
    {
        private MediaTypeWithQualityHeaderValue Header;
        private readonly string urlApiDoct;
        private HttpClient httpClient;

        public ServiceDoctores(IConfiguration configuration)
        {
            this.urlApiDoct = configuration.GetValue<string>("ApiUrls:ApiDoct")!;
            Header = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient = new HttpClient();
        }

        public async Task<List<Doctor>?> GetDoctores()
        {
            string query = "/";
            List<Doctor>? doctores = await GetResponse<List<Doctor>>(query);
            return doctores;
        }

        public async Task<Doctor?> GetDoctor()
        {
            string query = "";
            Doctor? doctor = await GetResponse<Doctor>(query);
            return doctor;
        }

        public async Task PutDoct(int idHospital, int idDoctor, string apellido, string especialidad, int salario)
        {
            string query = "";
            Doctor doctor = new Doctor()
            {
                IdHospital = idHospital,
                IdDoctor = idDoctor,
                Apellido = apellido,
                Especialidad = especialidad,
                Salario = salario
            };
            httpClient.BaseAddress = new Uri(urlApiDoct);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Append(Header);
            string json = JsonSerializer.Serialize(doctor);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(query, content);
        }

        public async Task DeleteDoct(int id)
        {
            string query = "" + id;
            httpClient.BaseAddress = new Uri(urlApiDoct);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(Header);
            HttpResponseMessage response = await httpClient.DeleteAsync(query);
        }

        public async Task CreateDoct(int idHospital, string apellido, string especialidad, int salario)
        {
            string query = "";
            Doctor doctor = new Doctor()
            {
                IdHospital = idHospital,
                Apellido = apellido,
                Especialidad = especialidad,
                Salario = salario
            };
            httpClient.BaseAddress = new Uri(urlApiDoct);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(Header);
            string json = JsonSerializer.Serialize(doctor);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(query, content);
        }

        public async Task<T?> GetResponse<T>(string query)
        {
            httpClient.BaseAddress = new Uri(urlApiDoct);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Append(Header);
            HttpResponseMessage response = await httpClient.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                T data = await response.Content.ReadAsAsync<T>();
                return data;
            }
            else
            {
                return default(T);
            }
        }
    }
}
