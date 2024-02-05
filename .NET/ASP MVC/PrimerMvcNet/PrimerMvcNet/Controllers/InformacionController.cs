using Microsoft.AspNetCore.Mvc;
using PrimerMvcNet.Models;

namespace PrimerMvcNet.Controllers
{
    public class InformacionController : Controller
    {

        public IActionResult ControladorVista()
        {
            Persona persona = new Persona();
            persona.Nombre = "MARCOS";
            persona.Apellidos = "MADRID";
            persona.Edad = 20;
            return View("ControladorVista", persona);
        }

        [HttpGet]
        public IActionResult ControladorVistaGet(string app, Nullable<Int32> version)
        {           
            ViewBag.App = app;
            ViewBag.Version = version;
            return View();
        }
    }


}
