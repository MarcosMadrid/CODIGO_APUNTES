using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Controllers
{
    public class MascotasController : Controller
    {
        static List<Mascota> mascotas = new List<Mascota>();
        [HttpGet, HttpPost]
        public IActionResult MascotasTableView(Mascota mascota)
        {
            if (mascota.Raza == null || mascota.Raza == null || mascota.Edad == 0)
            {
                return View(mascotas);
            }
            else
            {
                mascotas.Add(mascota);
                return View(mascotas);
            }
        }
    }
}
