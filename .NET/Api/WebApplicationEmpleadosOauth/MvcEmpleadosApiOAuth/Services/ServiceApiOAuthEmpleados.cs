using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using WebApplicationEmpleadosOauth.Models;

namespace MvcEmpleadosApiOAuth.Services
{
    public class ServiceApiOAuthEmpleados : IServiceEmpleados
    {
        private string ApiUrl;
        private MediaTypeWithQualityHeaderValue mediaType;
        private string? token;

        public ServiceApiOAuthEmpleados(IConfiguration configuration, IHttpContextAccessor httpContext)
        {
            this.ApiUrl = configuration.GetValue<string>("UrlsApi:ApiOAuthEmp")!;
            mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            this.token = httpContext.HttpContext!.User!.FindFirst(x => x.Type == "token")?.Value;
        }

        public async Task<string?> GetToken(string username, string password)
        {
            string request = "/api/Auth/Login";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                LoginModel loginModel = new LoginModel()
                {
                    Password = password,
                    UserName = username,
                };
                string jsonData = JsonConvert.SerializeObject(loginModel);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await client.PostAsync(request, stringContent);
                if (httpResponse.IsSuccessStatusCode)
                {
                    JObject keys = JObject.Parse(await httpResponse.Content.ReadAsStringAsync());
                    token = keys.GetValue("response")!.ToString();
                    return token;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Empleado?> GetPerfil()
        {
            string request = "/api/Empleado/GetProfile";
            Empleado? emp = await GetApiResponse<Empleado>(request);
            return emp;
        }

        public async Task<T?> GetApiResponse<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.BaseAddress = new Uri(this.ApiUrl);
                HttpResponseMessage httpResponse = await client.GetAsync(request);
                if (httpResponse.IsSuccessStatusCode)
                {
                    T data = await httpResponse.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Empleado>?> GetEmpleados()
        {
            string request = "/api/Empleados/GetEmpleados";
            return
                await GetApiResponse<List<Empleado>>(request);
        }

        public async Task<List<Empleado>?> GetEmpleadosDept()
        {
            string request = "/api/Empleados/GetProfile";
            return
                await GetApiResponse<List<Empleado>>(request);
        }


        public async Task<Empleado?> GetEmpleado(int id)
        {
            string request = "/api/Empleados/GetEmpleado/" + id;
            return
                await GetApiResponse<Empleado>(request);
        }

        public async Task<List<Empleado>?> GetEmpleadosDeptUser()
        {
            string request = "/api/Empleados/GetEmpleadosDeptUser";
            return
                await GetApiResponse<List<Empleado>>(request);
        }
    }
}
