using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WCFLogicaCoches.Models;

namespace WCFLogicaCoches.Repositories
{
    public class RepositoryCoches
    {
        private XDocument document;

        public RepositoryCoches()
        {
            string resourceName = "WCFLogicaCoches.coches.xml";
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resourceName);
            this.document = XDocument.Load(stream);
        }


        public List<Coche> GetCoches()
        {
            List<Coche> coches = document.Descendants("coche").Select(coche =>
            {
                return
                   new Coche()
                   {
                       IdCoche = int.Parse(coche.Element("idcoche").Value),
                       Marca = coche.Element("marca").Value,
                       Modelo = coche.Element("modelo").Value,
                       Imagen = coche.Element("imagen").Value,
                   };
            })
            .ToList();

            return coches;
        }

        public Coche GetCoche(int id)
        {
            Coche coche = GetCoches().FirstOrDefault(x => x.IdCoche.Equals(id));
            return coche;
        }
    }
}
