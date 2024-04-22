using Azure.Data.Tables;
using MvcCoreSasStorage.Models;
using Newtonsoft.Json.Linq;
using System.Net;

namespace MvcCoreSasStorage.Services
{
    public class ServiceAzureAlumnos
    {
        private TableClient tableAlumnos;
        private string UrlApiStorage;

        public ServiceAzureAlumnos(IConfiguration configuration)
        {
            this.UrlApiStorage = configuration.GetValue<string>("ApiUrls:ApiTokenUrl")!;
        }

        public async Task<string?> GetAccessUrl(string curso)
        {
            using (WebClient client = new WebClient())
            {
                string request = "token/" + curso;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.BaseAddress = UrlApiStorage;
                string data = await client.DownloadStringTaskAsync(request);
                JObject dataJson = JObject.Parse(data);
                string token = dataJson.GetValue("accessUrl")!.ToString();
                return token;
            }
        }

        public async Task<List<Alumno>?> GetAlumnosAsync(string curso)
        {
            string? urlTableAlumnos = await GetAccessUrl(curso);
            if (urlTableAlumnos == null)
            {
                return null;
            }
            Uri uri = new Uri(urlTableAlumnos);
            tableAlumnos = new TableClient(uri);
            var query = tableAlumnos.QueryAsync<Alumno>(filter: "");
            List<Alumno> alumnos = new List<Alumno>();
            await foreach (Alumno alumno in query)
            {
                alumnos.Add(alumno);
            }
            return alumnos;
        }
    }
}
