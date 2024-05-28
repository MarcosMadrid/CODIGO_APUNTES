using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using WebApplicationPeliculas.Models;

namespace WebApplicationPeliculas.Services
{
    public class ServicePeliculas
    {
        private MediaTypeWithQualityHeaderValue header;

        public string? UrlApi { get; private set; }

        public ServicePeliculas()
        {
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T?> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(request);

                    response.EnsureSuccessStatusCode();

                    string responseData = await response.Content.ReadAsStringAsync();

                    T? result = JsonConvert.DeserializeObject<T>(responseData);

                    return result;
                }
                catch (Exception ex)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task<List<Pelicula>?> GetPeliculas()
        {
            string request = "api/peliculas";
            List<Pelicula>? peliculas = new List<Pelicula>();
            peliculas = await this.CallApiAsync<List<Pelicula>>(request);
            return peliculas;
        }

        public async Task<List<Pelicula>?> GetPeliculasActores(string actor)
        {
            string request = "api/peliculas/find/" + actor;
            List<Pelicula>? peliculas = new List<Pelicula>();
            peliculas = await this.CallApiAsync<List<Pelicula>>(request);
            return peliculas;
        }

        public async Task<Pelicula?> GetPelicula(int id)
        {
            string request = "api/get/" + id;
            Pelicula? pelicula = await this.CallApiAsync<Pelicula>(request);
            return pelicula;
        }

        public async Task CreatePelicula(Pelicula pelicula)
        {
            string query = "";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string json = JsonConvert.SerializeObject(pelicula);
                StringContent stringContent = new StringContent(json, this.header);
                HttpResponseMessage response = await client.PostAsync(query, stringContent);

                return;
            }
        }

        public async Task PutPelicula(Pelicula pelicula)
        {
            string query = "";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string json = JsonConvert.SerializeObject(pelicula);
                StringContent stringContent = new StringContent(json, this.header);
                HttpResponseMessage response = await client.PutAsync(query, stringContent);

                return;
            }
        }

        public async Task DeletePelicula(Pelicula pelicula)
        {
            string query = "";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.DeleteAsync(this.UrlApi);

                return;
            }
        }
    }
}
