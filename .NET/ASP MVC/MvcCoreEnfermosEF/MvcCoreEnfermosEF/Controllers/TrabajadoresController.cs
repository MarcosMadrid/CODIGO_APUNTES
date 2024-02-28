using Microsoft.AspNetCore.Mvc;
using MvcCoreEnfermosEF.Models;
using MvcCoreEnfermosEF.Repositories;

namespace MvcCoreEnfermosEF.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly RepositoryTrabajadores repositoryTrabajadores;

        public TrabajadoresController(RepositoryTrabajadores repositoryTrabajadores)
        {
            this.repositoryTrabajadores = repositoryTrabajadores;
        }

        public async Task<IActionResult> Index()
        {
            List<string> oficios = await repositoryTrabajadores.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            TrabajadoresModel trabajadoresModel = await repositoryTrabajadores.GetTrabajadoresModelAsync(oficios.FirstOrDefault());
            return View(trabajadoresModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string oficio)
        {
            ViewData["OFICIOS"] = await repositoryTrabajadores.GetOficiosAsync();
            TrabajadoresModel trabajadoresModel = await repositoryTrabajadores.GetTrabajadoresModelAsync(oficio);
            return View(trabajadoresModel);
        }

    }
}
