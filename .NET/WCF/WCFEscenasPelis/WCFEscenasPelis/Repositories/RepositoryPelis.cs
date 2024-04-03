using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WCFEscenasPelis.Repositories
{
    public class RepositoryPelis
    {
        XDocument document;

        public RepositoryPelis()
        {
            string resuorceName = "WCFEscenasPelis.escenaspeliculas.xml";
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resuorceName);
            this.document = XDocument.Load(stream);
        }

        public List<Pelicula> GetPeliculas()
        {
            List<Pelicula> peliculas = document.Descendants("escena")
                .Select(pelicula =>
                {
                    return
                     new Pelicula()
                     {
                         Id = int.Parse(pelicula.Attribute("idpelicula").Value),
                         Name = pelicula.Element("tituloescena").Value,
                         Description = pelicula.Element("descripcion").Value,
                         Image = pelicula.Element("imagen").Value,
                     };
                }).ToList();
            return peliculas;
        }

        public List<Pelicula> GetPeliculaEscenas(int id)
        {
            return GetPeliculas().Where(pelicula => pelicula.Id.Equals(id)).ToList();
        }

    }
}
