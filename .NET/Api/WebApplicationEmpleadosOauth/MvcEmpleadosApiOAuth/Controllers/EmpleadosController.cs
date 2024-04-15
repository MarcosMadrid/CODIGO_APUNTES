using Microsoft.AspNetCore.Mvc;
using MvcEmpleadosApiOAuth.Filters;
using MvcEmpleadosApiOAuth.Services;
using WebApplicationEmpleadosOauth.Models;

namespace MvcEmpleadosApiOAuth.Controllers
{
    [AuthorizeEmpFilter]
    public class EmpleadosController : Controller
    {
        private IServiceEmpleados serviceEmpleados;

        public EmpleadosController(IServiceEmpleados serviceEmpleados)
        {
            this.serviceEmpleados = serviceEmpleados;
        }

        public async Task<IActionResult> Index()
        {
            List<Empleado>? empleados = await serviceEmpleados.GetEmpleados();
            return View(empleados);
        }

        public async Task<IActionResult> ListEmpleadosDept()
        {
            List<Empleado>? empleados = await serviceEmpleados.GetEmpleadosDeptUser();
            return View("Index", empleados);
        }

        public async Task<IActionResult> Details(int id)
        {
            Empleado? emp = await serviceEmpleados.GetEmpleado(id);
            return View(emp);
        }
    }
}
