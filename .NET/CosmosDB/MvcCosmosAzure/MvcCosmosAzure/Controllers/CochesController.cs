using Microsoft.AspNetCore.Mvc;
using MvcCosmosAzure.Models;
using MvcCosmosAzure.Services;

namespace MvcCosmosAzure.Controllers
{
    public class CochesController : Controller
    {
        private ServiceCosmosDb cosmosDb;

        public CochesController(ServiceCosmosDb cosmosDb)
        {
            this.cosmosDb = cosmosDb;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string accion)
        {
            try
            {
                await this.cosmosDb.CreateDatabaseAsync();
                ViewData["MENSAJE"] = "Recursos creados de Azure";
            }
            catch (Exception ex)
            {
                ViewData["MENSAJE"] = ex.Message.ToString();
            }
            return View();
        }

        public async Task<IActionResult> ListCoches()
        {
            List<Vehiculo> vehiculos = await cosmosDb.GetVehiculosAsync();
            return View(vehiculos);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await cosmosDb.DeleteVehiculoAsync(id);
            return RedirectToAction("ListCoches");
        }

        public async Task<IActionResult> Details(string id)
        {
            Vehiculo vehiculo = await cosmosDb.FindVehiculoAsync(id);
            return View(vehiculo);
        }

        public async Task<IActionResult> Edit(string id)
        {
            Vehiculo vehiculo = await cosmosDb.FindVehiculoAsync(id);
            return View(vehiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Vehiculo vehiculo)
        {
            await cosmosDb.UpdateVehiculoAsync(vehiculo);
            return RedirectToAction("ListCoches");
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehiculo vehiculo)
        {
            await cosmosDb.InsertVehiculoAsync(vehiculo);
            return RedirectToAction("ListCoches");
        }
    }
}
