using Microsoft.AspNetCore.Mvc;
using MvcEmpleadosApiOAuth.Filters;
using MvcEmpleadosApiOAuth.Services;
using WebApplicationEmpleadosOauth.Models;

namespace MvcEmpleadosApiOAuth.Controllers
{
    public class EmpleadosController : Controller
    {
        private IServiceEmpleados serviceEmpleados;

        public EmpleadosController(IServiceEmpleados serviceEmpleados)
        {
            this.serviceEmpleados = serviceEmpleados;
        }
        
        [AuthorizeEmpFilter]
        public async Task<IActionResult> Index()
        {
            List<Empleado>? empleados = await serviceEmpleados.GetEmpleados();
            return View(empleados);
        }

        [AuthorizeEmpFilter]
        public async Task<IActionResult> Details(int id)
        {
            string? token = HttpContext.Session.GetString("token");
            if (token is null)
            {
                ViewData["MENSAJE"] = "Debe iniciar sesión";
                return View();
            }
            Empleado? emp = await serviceEmpleados.GetEmpleado(id, token);
            return View(emp);
        }
    }
}
