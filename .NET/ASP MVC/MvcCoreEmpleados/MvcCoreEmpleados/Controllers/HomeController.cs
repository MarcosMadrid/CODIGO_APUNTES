using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MvcCoreEmpleados.Models;
using MvcCoreEmpleados.Repositories;
using MvcCoreSession.Extensions;
using System.Diagnostics;

namespace MvcCoreEmpleados.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositoryViewEmpleadosSQLServer repository;
        private IMemoryCache memoryCache;

        public HomeController(ILogger<HomeController> logger, RepositoryViewEmpleadosSQLServer repository, IMemoryCache memoryCache)
        {
            _logger = logger;
            this.repository = repository;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SessionEmpleadosOK(int? id)
        {
            List<int> idsEmpleados = new List<int>();
            List<Empleado>? listEmpleados = null;
            List<Empleado> empleadosFavoritos = new List<Empleado>();
            if (!memoryCache.TryGetValue("FAVORITOS", out empleadosFavoritos))
            {
                memoryCache.Set("FAVORITOS", empleadosFavoritos);
            }

            if (id != null)
            {
                if (HttpContext.Session.GetString("IDEMPLEADOS") == null)
                {
                    idsEmpleados = new List<int>();
                }
                else
                {
                    idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDEMPLEADOS")!;
                }
                if (idsEmpleados.Contains(id.Value))
                {
                    idsEmpleados.Remove(id.Value);
                }
                else
                {
                    idsEmpleados.Add(id.Value);
                    //listEmpleados = await repository.GetEmpleadosNoIdsAsync(idsEmpleados);
                }
            }
            else
            {
                if (!HttpContext.Session.Keys.Contains("IDEMPLEADOS"))
                {
                    listEmpleados = await repository.GetEmpleadosAsync();
                }
                else
                {
                    idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDEMPLEADOS")!;
                }
            }
            
            listEmpleados = await repository.GetEmpleadosAsync();
            HttpContext.Session.SetObject("IDEMPLEADOS", idsEmpleados);


            ViewData["MENSAJE"] = "Empleados guardados:" + idsEmpleados.Count();
            return View(listEmpleados);
        }

        public async Task<IActionResult> EmpleadosAlmacenadosOk()
        {
            List<int> idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDEMPLEADOS")!;
            List<Empleado> empleados = await repository.GetEmpleadosByIdsAsync(idsEmpleados);

            return View(empleados);
        }

        public async Task<IActionResult> EmpleadosFavoritos(int id)
        {
            List<Empleado>? empleadosFavoritos = null;
            Empleado? empleado = null;

            empleado = await repository.GetEmpleadoAsync(id);

            if (memoryCache.TryGetValue("FAVORITOS", out empleadosFavoritos))

            {
                if (empleadosFavoritos is null)
                {
                    empleadosFavoritos = new List<Empleado>();
                }

                if (empleado is not null)
                {
                    if (!empleadosFavoritos.Select(empleado => empleado.IdEmpleado).ToList().Contains(empleado.IdEmpleado))
                    {
                        empleadosFavoritos.Add(empleado);
                        memoryCache.Set("FAVORITOS", empleadosFavoritos);
                    }
                    else
                    {
                        empleadosFavoritos.RemoveAll(empleadoRow => empleadoRow.IdEmpleado == empleado.IdEmpleado);
                        memoryCache.Set("FAVORITOS", empleadosFavoritos);
                    }
                }
            }
            return RedirectToAction("SessionEmpleadosOK");
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
