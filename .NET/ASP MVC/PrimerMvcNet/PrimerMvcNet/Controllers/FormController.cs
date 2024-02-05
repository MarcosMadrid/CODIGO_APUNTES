using Microsoft.AspNetCore.Mvc;
using PrimerMvcNet.Models;

namespace PrimerMvcNet.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormView(Persona persona)
        {
            return View(persona);
        }
    }
}
