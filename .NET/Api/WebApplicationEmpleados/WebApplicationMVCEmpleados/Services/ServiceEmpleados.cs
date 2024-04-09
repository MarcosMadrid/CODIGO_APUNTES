using System.Net.Http.Headers;
using WebApplicationEmpleados.Models;

namespace WebApplicationMVCEmpleados.Services
{
    public class ServiceEmpleados
    {
        private MediaTypeWithQualityHeaderValue Header;
        private readonly string urlApiEmpleados;

        public ServiceEmpleados(IConfiguration configuration)
        {
            this.urlApiEmpleados = configuration.GetValue<string>("ApiUrls:ApiEmpleados")!;
            Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Empleado>?> GetEmpleados()
        {
            string query = "api/Empleados/GetEmpleados";
            List<Empleado>? empleados = await GetApiResponse<List<Empleado>>(query);
            return empleados;
        }

        public async Task<List<string>?> GetOficios()
        {
            string query = "api/Empleados/GetOficios";
            List<string>? oficios = await GetApiResponse<List<string>>(query);
            return oficios;
        }

        public async Task<List<Empleado>?> GetEmpleadosOficio(string oficio)
        {
            string query = "api/Empleados/GetEmpleadosOficio/" + oficio;
            List<Empleado>? empleados = await GetApiResponse<List<Empleado>>(query);
            return empleados;
        }

        public async Task<Empleado?> GetEmpleado(int idEmpleado)
        {
            string query = "api/Empleados/GetEmpleado/" + idEmpleado;
            Empleado? empleado = await GetApiResponse<Empleado>(query);
            return empleado;
        }

        public async Task<T?> GetApiResponse<T>(string request)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlApiEmpleados);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(Header);
                HttpResponseMessage response = await httpClient.GetAsync(request);
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
}
