using Microsoft.AspNetCore.Mvc;
using WebApplicationEmpleados.Models;
using WebApplicationMVCEmpleados.Services;

namespace WebApplicationMVCEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private ServiceEmpleados serviceEmpleados;
        public EmpleadosController(ServiceEmpleados serviceEmpleados)
        {
            this.serviceEmpleados = serviceEmpleados;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Empleado>? empleados = await serviceEmpleados.GetEmpleados();
            List<string>? oficios = await serviceEmpleados.GetOficios();
            ViewData["oficios"] = oficios;
            return View(empleados);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string oficio)
        {
            List<Empleado>? empleados = await serviceEmpleados.GetEmpleadosOficio(oficio);
            List<string>? oficios = await serviceEmpleados.GetOficios();
            ViewData["oficios"] = oficios;
            return View(empleados);
        }

        public async Task<IActionResult> Details(int id)
        {
            Empleado? empleado = await serviceEmpleados.GetEmpleado(id);
            return View(empleado);
        }
    }
}
