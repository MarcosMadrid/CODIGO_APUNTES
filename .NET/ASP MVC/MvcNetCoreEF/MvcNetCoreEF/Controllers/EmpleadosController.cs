using Microsoft.AspNetCore.Mvc;
using MvcNetCoreEF.Models;
using MvcNetCoreEF.Repositories;

namespace MvcNetCoreEF.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly RepositoryEmpleado repositoryEmpleado;

        public EmpleadosController(RepositoryEmpleado repositoryEmpleado)
        {
            this.repositoryEmpleado = repositoryEmpleado;
        }

        public IActionResult Index()
        {
            ViewData["OFICIOS"] = repositoryEmpleado.GetOficios();
            List<Empleado>? empleados = repositoryEmpleado.GetEmpleados();
            return View(empleados);
        }

        public IActionResult IncrementarSalario(int incremento, string oficio)
        {
            repositoryEmpleado.IncerementarSalarioOficios(incremento, oficio);
            return RedirectToAction("Index");
        }
    }
}
