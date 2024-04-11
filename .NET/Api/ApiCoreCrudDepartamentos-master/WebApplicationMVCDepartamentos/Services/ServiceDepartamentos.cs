using ApiCoreCrudDepartamentos.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WebApplicationMVCDepartamentos.Services
{
    public class ServiceDepartamentos
    {
        private readonly string UrlApiDept;
        private MediaTypeWithQualityHeaderValue Header;
        private HttpClient httpClient;

        public ServiceDepartamentos(IConfiguration configuration)
        {
            UrlApiDept = configuration["ApiUrls:ApiDepartamentos"]!;
            Header = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient = new HttpClient();
        }

        public async Task<List<Departamento>?> GetDepartamentosAsync()
        {
            string query = "/api/Departamentos/GetDepartamentos";
            return
                await GetResponse<List<Departamento>>(query);
        }

        public async Task<Departamento?> GetDepartamentoAsync(int id)
        {
            string query = "/api/Departamentos/GetDepartamento/" + id;
            return
                await GetResponse<Departamento>(query);
        }

        public async Task PostDepartamento(int id, string nombre, string localidad)
        {
            string request = "/api/Departamentos/PostDepartamento";
            httpClient.BaseAddress = new Uri(UrlApiDept);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(Header);
            Departamento departamento = new Departamento() 
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            string json = JsonSerializer.Serialize(departamento);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(request, content);            
        }

        public async Task PutDepartamento(int id, string nombre, string localidad)
        {
            string request = "/api/Departamentos/PutDepartamento";
            httpClient.BaseAddress = new Uri(UrlApiDept);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(Header);
            Departamento departamento = new Departamento()
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            string json = JsonSerializer.Serialize(departamento);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(request, content);
        }

        public async Task DeleteDepartamento(int id)
        {
            string request = "/api/Departamentos/DeleteDepartamento/" + id;
            httpClient.BaseAddress = new Uri(UrlApiDept);
            httpClient.DefaultRequestHeaders.Clear();            
            HttpResponseMessage response = await httpClient.DeleteAsync(request);
        }

        public async Task<T?> GetResponse<T>(string query)
        {           
            httpClient.BaseAddress = new Uri(UrlApiDept);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(Header);
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
