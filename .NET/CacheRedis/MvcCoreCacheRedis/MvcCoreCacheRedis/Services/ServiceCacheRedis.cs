using MvcCoreCacheRedis.Helpers;
using MvcCoreCacheRedis.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MvcCoreCacheRedis.Services
{
    public class ServiceCacheRedis
    {
        private IDatabase database;

        public ServiceCacheRedis()
        {
            this.database = HelperCacheMultiplexer.Connection.GetDatabase();
        }

        public async Task AddProductoFavorito(Producto producto)
        {
            string? jsonProductos = await database.StringGetAsync("fav");
            List<Producto>? productos;
            if (jsonProductos == null)
            {
                productos = new List<Producto>();
            }
            else
            {
                productos = JsonConvert.DeserializeObject<List<Producto>>(jsonProductos!)!;
            }
            productos.Add(producto);
            jsonProductos = JsonConvert.SerializeObject(productos);
            await database.StringSetAsync("fav", jsonProductos);
        }

        public async Task<List<Producto>?> GetProductos()
        {
            string? jsonData = await database.StringGetAsync("fav");
            if (jsonData == null)
            {
                return null;
            }
                
            return
                JsonConvert.DeserializeObject<List<Producto>>(jsonData);
        }

        public async Task DeleteProductoFavoritoAsync(int id)
        {
            List<Producto>? productos;
            productos = await GetProductos();
            if (productos == null)
            {
                return;
            }
            if (productos.Count() - 1 <= 0)
            {
                await this.database.KeyDeleteAsync("fav");
                return;
            }
            Producto? producto = productos.FirstOrDefault(prod => prod.IdProducto.Equals(id));
            if (producto == null)
            {
                return;
            }
            productos.Remove(producto);
            string jsonData = JsonConvert.SerializeObject(productos);
            await database.StringSetAsync("fav", jsonData, TimeSpan.FromMinutes(15));
        }
    }
}
