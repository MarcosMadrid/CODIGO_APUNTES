using Microsoft.AspNetCore.Mvc;

namespace PrimerMvcNet.Controllers
{
    public class PruebaController : Controller
    {
        public IActionResult PrimeraPagina()
        {
            return View();
        }
    }
}
