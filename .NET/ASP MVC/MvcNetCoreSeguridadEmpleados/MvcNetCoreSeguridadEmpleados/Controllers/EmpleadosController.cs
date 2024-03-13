using Microsoft.AspNetCore.Mvc;
using MvcNetCoreSeguridadEmpleados.Filters;
using MvcNetCoreSeguridadEmpleados.Models;
using MvcNetCoreSeguridadEmpleados.Repositories;

namespace MvcNetCoreSeguridadEmpleados.Controllers
{
    [AuthorizeEmpleados]
    public class EmpleadosController : Controller
    {
        RepositoryEmpleados repositoryEmpleados;

        public EmpleadosController(RepositoryEmpleados repositoryEmpleados)
        {
            this.repositoryEmpleados = repositoryEmpleados;
        }

        public async Task<IActionResult> Index()
        {
            List<Empleado>? empleados = await repositoryEmpleados.GetEmpleadosAsync();
            return View(empleados);
        }

        public async Task<IActionResult> Details(int id)
        {
            Empleado? empleado = await repositoryEmpleados.GetEmpleadoAsync(id);
            return View(empleado);
        }

        public async Task<IActionResult> Perfil()
        {
            
            return RedirectToAction("Details", new {id = HttpContext.User.Identity.Name});
        }
    }
}
