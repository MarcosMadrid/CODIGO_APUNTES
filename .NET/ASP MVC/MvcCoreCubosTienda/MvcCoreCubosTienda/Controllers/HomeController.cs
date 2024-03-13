using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MvcCoreCubosTienda.Models;
using MvcCoreCubosTienda.Repositories;
using System.Diagnostics;

namespace MvcCoreCubosTienda.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        private IRepositoryCubosBBDD cubosBBDD;
        private IMemoryCache memoryCache;

        public HomeController(ILogger<HomeController> logger, IRepositoryCubosBBDD cubosBBDD, IMemoryCache memoryCache)
        {
            _logger = logger;
            this.cubosBBDD = cubosBBDD;
            this.memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            List<Cubo>? cubos = await cubosBBDD.GetCubos();
            return View(cubos);
        }

        [HttpGet]
        public IActionResult Carrito()
        {
            List<Compra>? compras;
            if (!memoryCache.TryGetValue("CARRITO", out compras))
            {
                ViewData["MENSAJE"] = "Tu carrito esta vacio";
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Comprar()
        {
            List<Compra>? compras;
            if (memoryCache.TryGetValue("CARRITO", out compras))
            {
                return BadRequest();
            }
            else
            {
                foreach (Compra compra in compras!)
                {
                    await cubosBBDD.CreateCompraAsync(compra.Name!, compra.Precio, DateTime.UtcNow);
                }

            }
            return View("Index");
        }

        public async Task<IActionResult> AddCarritoCompra(int id)
        {
            List<Compra>? listaCompra;
            if (!this.memoryCache.TryGetValue("CARRITO", out listaCompra))
            {
                listaCompra = new List<Compra>();
                memoryCache.Set("CARRITO", listaCompra);
            }

            Cubo? cubo = await cubosBBDD.GetCuboById(id);
            if (cubo != null)
            {
                Compra compra = new Compra
                {
                    Name = cubo.Name,
                    Precio = cubo.Precio
                };

                listaCompra!.Add(compra);
            }
            else
            {
                return NotFound();
            }
            memoryCache.Set("CARRITO", listaCompra);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCarritoCompra(int id)
        {
            List<Compra>? listaCompra;
            if (!this.memoryCache.TryGetValue("CARRITO", out listaCompra))
            {
                return BadRequest();
            }

            Cubo? cubo = await cubosBBDD.GetCuboById(id);
            if (cubo != null)
            {
                listaCompra!.RemoveAll(compraRow => compraRow.Name!.Equals(cubo.Name));
            }
            else
            {
                return NotFound();
            }
            memoryCache.Set("CARRITO", listaCompra);
            return RedirectToAction("Carrito");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
