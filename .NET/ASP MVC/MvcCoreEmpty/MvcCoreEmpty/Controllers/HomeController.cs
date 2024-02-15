using Microsoft.AspNetCore.Mvc;
using MvcCoreEmpty.Models;

namespace MvcCoreEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contenido()
        {
            return View();
        }

        public IActionResult VistaPersona()
        {
            Persona persona = new Persona();
            persona.Nombre = "Marcos";
            persona.Edad = 21;
            persona.Sex = "Macho";
            return View(persona);
        }
    }
}
