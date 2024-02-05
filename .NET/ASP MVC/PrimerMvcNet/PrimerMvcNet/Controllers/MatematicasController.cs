using Microsoft.AspNetCore.Mvc;

namespace PrimerMvcNet.Controllers
{
    public class MatematicasController : Controller
    {
        [HttpPost]
        public IActionResult SumarNumeros(int? val1, int? val2)
        {
            ViewData["VAL1"] = val1;
            ViewData["VAL2"] = val2;
            return View();
        }

        [HttpGet]
        public IActionResult SumarNumerosForm()
        {
            return View();
        }

        [HttpPost,HttpGet]
        public IActionResult TablaMultiplicarSimple(int? num)
        {
            ViewBag.Num = num;
            return View();
        }
    }
}
