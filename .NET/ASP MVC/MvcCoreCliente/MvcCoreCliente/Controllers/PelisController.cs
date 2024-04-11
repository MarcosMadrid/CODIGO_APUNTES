using Microsoft.AspNetCore.Mvc;
using MvcCoreCliente.Services;
using ServiceReferenceEscenasPelis;

namespace MvcCoreCliente.Controllers
{
    public class PelisController : Controller
    {
        ServiceEscenas escenas;

        public PelisController(ServiceEscenas escenas)
        {
            this.escenas = escenas;
        }

        public async Task<IActionResult> Index()
        {
            Pelicula[] peliculas = await escenas.GetPeliculasAsync();
            return View(peliculas);
        }
    }
}
