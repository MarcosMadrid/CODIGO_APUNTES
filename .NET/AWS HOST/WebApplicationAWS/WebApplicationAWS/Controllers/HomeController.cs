using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationAWS.Models;
using WebApplicationAWS.Repositories;

namespace WebApplicationAWS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositoryDept repositoryDept;

        public HomeController(ILogger<HomeController> logger, RepositoryDept repositoryDept)
        {
            _logger = logger;
            this.repositoryDept = repositoryDept;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento>? depts = await repositoryDept.GetDepartamentos();
            return View(depts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await repositoryDept.CreateDept(departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await repositoryDept.DeleteDept(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Departamento? dept = await repositoryDept.GetDepartamento(id);
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento departamento)
        {
            await repositoryDept.UpdateDept(departamento.Id, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento? dept = await repositoryDept.GetDepartamento(id);
            return View(dept);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
