using Microsoft.AspNetCore.Mvc;
using MvcCoreCacheRedis.Models;
using MvcCoreCacheRedis.Repositories;
using MvcCoreCacheRedis.Services;

namespace MvcCoreCacheRedis.Controllers
{
    public class HomeController : Controller
    {
        private RepositoryProductos repositoryProductos;
        private ServiceCacheRedis serviceCache;

        public HomeController(RepositoryProductos repositoryProductos, ServiceCacheRedis serviceCache)
        {
            this.repositoryProductos = repositoryProductos;
            this.serviceCache = serviceCache;
        }

        public async Task<IActionResult> Index()
        {
            List<Producto>? products = new List<Producto>();
            List<Producto>? productsFav = new List<Producto>();
            products = repositoryProductos.GetProductos();
            productsFav = await serviceCache.GetProductos();
            ViewData["fav"] = productsFav;
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Producto? producto = new Producto();
            producto = repositoryProductos.GetProducto(id);
            return View(producto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await serviceCache.DeleteProductoFavoritoAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddFav(int id)
        {
            Producto? producto = new Producto();
            producto = repositoryProductos.GetProducto(id);
            if (producto != null)
            {
                await serviceCache.AddProductoFavorito(producto);
            }
            return RedirectToAction("Index");
        }
    }
}
