using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqToSql.Models;
using MvcCoreLinqToSql.Repositories;

namespace MvcCoreLinqToSql.Controllers
{
    public class EmpleadosController : Controller
    {
        RepositoryEmp RepositoryEmp = new RepositoryEmp();
        public IActionResult EmpleadosTable()
        {
            List<Empleado> empleados = new List<Empleado>();
            List<string> oficios = new List<string>();

            empleados = RepositoryEmp.GetEmpleados();
            oficios = RepositoryEmp.GetOficiosEmpleados();

            ViewBag.OFICIOS = oficios;
            return View(empleados);
        }

        [HttpPost]
        public IActionResult SearchEmpleadosOficio(string oficio)
        {
            List<Empleado>? empleados = new List<Empleado>();
            List<string> oficios = new List<string>();

            empleados = RepositoryEmp.GetEmpleadosByOficio(oficio);
            oficios = RepositoryEmp.GetOficiosEmpleados();

            ViewBag.OFICIOS = oficios;
            return View("EmpleadosTable", empleados);
        }
    }
}
