using ConsoleAppChollometro.Data;
using ConsoleAppChollometro.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;

namespace ConsoleAppChollometro.Repositories
{
    public class RepositoryChollometro
    {
        private CholloContext cholloContext;
        public RepositoryChollometro(CholloContext context)
        {
            cholloContext = context;
        }

        public async Task<List<Chollo>> GetChollosWebAsync()
        {
            string url = "https://www.chollometro.com/rss";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Accept = @"text/html application/xhtml+xml, *.*";
            webRequest.Referer = url;
            webRequest.Headers.Add("Accept-lenguage", "es-ES");
            webRequest.Host = "www.chollometro.com";
            webRequest.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            HttpWebResponse response = (HttpWebResponse)await webRequest.GetResponseAsync();

            string xmlData = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                xmlData = await reader.ReadToEndAsync();
            }

            XDocument document = XDocument.Parse(xmlData);

            List<XElement> chollosXml = document.Descendants("item").ToList();
            List<Chollo> chollos = new List<Chollo>();

            int idMax = await GetMaxCholloIdAsync();
            foreach (XElement item in chollosXml)
            {
                Chollo chollo = new Chollo()
                {
                    Id = idMax,
                    Titulo = item.Element("title").Value,
                    Link = item.Element("link").Value,
                    Descripcion = item.Element("description").Value,
                    Fecha = DateTime.UtcNow
                };
                idMax++;
                chollos.Add(chollo);
            }

            return chollos;
        }

        public async Task<int> GetMaxCholloIdAsync()
        {
            if (this.cholloContext.Chollos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return
                    await this.cholloContext.Chollos.MaxAsync(chollo => chollo.Id) + 1;
            }
        }

        public async Task PopulateChollosAzure()
        {
            this.cholloContext.Chollos.RemoveRange();
            List<Chollo> chollos = await this.GetChollosWebAsync();
            foreach (Chollo item in chollos)
            {
                this.cholloContext.Add(item);
            }
            await this.cholloContext.SaveChangesAsync();
        }

        public async Task<List<Chollo>> GetChollosAsync()
        {
            return
                await this.cholloContext.Chollos.ToListAsync();
        }

        public async Task<Chollo?> GetCholloAsync(int id)
        {
            return
                await this.cholloContext.Chollos.FirstOrDefaultAsync(chollo => chollo.Id.Equals(id));
        }
    }
}
