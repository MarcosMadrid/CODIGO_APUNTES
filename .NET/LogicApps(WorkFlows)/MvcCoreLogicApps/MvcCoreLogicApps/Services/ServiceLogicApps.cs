using Amqp.Types;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcCoreLogicApps.Services
{
    public class ServiceLogicApps
    {
        private MediaTypeWithQualityHeaderValue media;

        public ServiceLogicApps()
        {
            this.media = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task SendEmail(string email, string asunto, string mensaje)
        {
            string urlLogico = "/workflows/731316fba3d64bc698140a7c26ea53fc/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=1.0&sig=SSZ8gzhiRGB-jdUPDjjgGgsDyxTNO-AxLWREk37beQs";
            var requestBody = new
            {
                asunto = asunto,
                email = email,
                mensaje = mensaje
            };

            string bodyJson = JsonConvert.SerializeObject(requestBody);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://prod-42.westeurope.logic.azure.com:443/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(media);
                StringContent content = new StringContent(bodyJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlLogico, content);
                Console.WriteLine(response.StatusCode + ": " + response.ReasonPhrase);
            }
        }
    }
}
