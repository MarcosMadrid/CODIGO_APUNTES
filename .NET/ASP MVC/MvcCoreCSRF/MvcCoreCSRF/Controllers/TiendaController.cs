using Microsoft.AspNetCore.Mvc;

namespace MvcCoreCSRF.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Productos()
        {
            if (HttpContext.Session.GetString("USUARIO") is null)
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Productos(string direccion, string[] producto)
        {
            if (HttpContext.Session.GetString("USUARIO") is null)
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
            TempData["DIRECCION"] = direccion;
            TempData["PRODUCTOS"] = producto;
            return RedirectToAction("PedidoFinal");
        }

        public IActionResult PedidoFinal()
        {
            string[] productos = TempData["PRODUCTOS"] as string[];
            ViewData["DIRECCION"] = TempData["DIRECCION"].ToString();
            return View("Pedido",productos);
        }
    }
}
