using Microsoft.AspNetCore.Mvc;
using MvcNetCoreSeguridadEmpleados.Filters;
using MvcNetCoreSeguridadEmpleados.Models;
using MvcNetCoreSeguridadEmpleados.Repositories;
using System.Security.Claims;

namespace MvcNetCoreSeguridadEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        readonly RepositoryEmpleados repositoryEmpleados;

        public EmpleadosController(RepositoryEmpleados repositoryEmpleados)
        {
            this.repositoryEmpleados = repositoryEmpleados;
        }

        [AuthorizeEmpleados]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("EMPLEADO"))
            {
                return RedirectToAction("Compis");
            }
            List<Empleado>? empleados = await repositoryEmpleados.GetEmpleadosAsync();
            return View(empleados);
        }

        [AuthorizeEmpleados]
        public async Task<IActionResult> Details(int id)
        {
            Empleado? empleado = await repositoryEmpleados.GetEmpleadoAsync(id);

            return View(empleado);
        }

        public IActionResult Perfil()
        {
            string id = User.Claims.First(c => c.Type == "idUser").Value;
            return RedirectToAction("Details", new { id });
        }

        [AuthorizeEmpleados]
        public async Task<IActionResult> Compis()
        {
            int idDept = int.Parse(User.FindFirstValue("idDept")!);
            List<Empleado> empleados = await repositoryEmpleados.GetEmpleadosDepartamentoAsync(idDept);
            return View(empleados);
        }
    }
}
