using Microsoft.AspNetCore.Mvc;
using MvcCoreCliente.Services;
using ServiceReferenceCoches;

namespace MvcCoreCliente.Controllers
{
    public class CochesController : Controller
    {
        ServiceCoches cochesService;

        public CochesController(ServiceCoches coches)
        {
            this.cochesService = coches;
        }

        public async Task<IActionResult> Index()
        {
            Coche[] coches = await cochesService.GetCoches();
            return View(coches);
        }

        public async Task<IActionResult> Details(int id)
        {
            Coche coche = await cochesService.GetCoche(id);

            return View(coche);
        }
    }
}
