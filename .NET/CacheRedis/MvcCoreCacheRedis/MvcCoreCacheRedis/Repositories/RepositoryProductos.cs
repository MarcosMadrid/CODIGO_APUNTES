using MvcCoreCacheRedis.Helpers;
using MvcCoreCacheRedis.Models;
using System.Xml.Linq;

namespace MvcCoreCacheRedis.Repositories
{
    public class RepositoryProductos
    {
        private XDocument document;

        public RepositoryProductos(HelperPathProvider helperPath)
        {
            string pathDo = helperPath.MapPath("productos.xml", Folders.Documents);
            document = XDocument.Load(pathDo);
        }

        public List<Producto>? GetProductos()
        {
            List<Producto>? productos = document.Descendants("producto")
                .Select(data => new Producto()
                {
                    IdProducto = int.Parse(data.Element("idproducto")!.Value),
                    Nombre = data.Element("nombre")!.Value,
                    Descripcion = data.Element("descripcion")!.Value,
                    Precio = int.Parse(data.Element("precio")!.Value),
                    Imagen = data.Element("imagen")!.Value,
                })
                .ToList();

            return productos;
        }

        public Producto? GetProducto(int id)
        {
            Producto? producto = GetProductos()?.FirstOrDefault(prod => prod.IdProducto.Equals(id));
            return producto;
        }
    }
}
