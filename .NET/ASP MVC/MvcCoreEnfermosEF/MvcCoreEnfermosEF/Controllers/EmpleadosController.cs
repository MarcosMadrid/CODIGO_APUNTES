using Microsoft.AspNetCore.Mvc;
using MvcCoreEnfermosEF.Models;
using MvcCoreEnfermosEF.Repositories;

namespace MvcCoreEnfermosEF.Controllers
{
    public class EmpleadosController : Controller
    {
        IRepoitoryHospital repositoryViewEmpleados;

        public EmpleadosController(IRepoitoryHospital repository)
        {
            repositoryViewEmpleados = repository;
        }

        public async Task<IActionResult> Index()
        {
            List<ViewEmpleado> empleados = await repositoryViewEmpleados.GetViewEmpleadosAsync();
            return View(empleados);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewEmpleado? empleado = await repositoryViewEmpleados.GetEmpleadoAsync(id);
            return View(empleado);
        }

        public IActionResult Delete()
        {
            return RedirectToAction("Index");
        }

    }
}
