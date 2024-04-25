using MvcCoreSasStorage.Models;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MvcCoreSasStorage.Helpers
{
    public class HelperXml
    {
        private XDocument document;

        public HelperXml()
        {
            string assemblyPath = "MvcCoreSasStorage.Documents.alumnos.xml";
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(assemblyPath);
            this.document = XDocument.Load(stream);
        }

        public List<Alumno> GetAlumnos()
        {
            var consulta = from datos in this.document.Descendants("alumno")
                           select new Alumno
                           {
                               IdAlumno = int.Parse(datos.Element("idalumno").Value),
                               Curso = datos.Element("curso").Value,
                               Nombre = datos.Element("nombre").Value,
                               Apellido = datos.Element("apellidos").Value,
                               Nota = int.Parse(datos.Element("nota").Value),
                           };
            return consulta.ToList();
        }
    }
}
