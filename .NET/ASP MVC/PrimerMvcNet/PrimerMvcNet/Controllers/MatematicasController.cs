using Microsoft.AspNetCore.Mvc;
using PrimerMvcNet.Models;

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
            if(num != null)
            {
                TablaMultiplicarModel tablaMultiplicarModel = new TablaMultiplicarModel();
                var count = 0;
                while(count != 11) {
                    tablaMultiplicarModel.TablaMultiplicarOperaciones.Add(num + "*" + count);
                    tablaMultiplicarModel.TablaMultiplicarResultados.Add((int)num * count);
                    count++;
                }
                return View(tablaMultiplicarModel);
            }
            return View();
        }
    }
}
