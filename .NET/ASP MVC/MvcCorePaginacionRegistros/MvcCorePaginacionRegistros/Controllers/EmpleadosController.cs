using Microsoft.AspNetCore.Mvc;
using MvcCorePaginacionRegistros.Models;
using MvcCorePaginacionRegistros.Repositories;

namespace MvcCorePaginacionRegistros.Controllers
{
    public class EmpleadosController : Controller
    {
        RepositoryHospital repositoryHospital;

        public EmpleadosController(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public async Task<IActionResult> EmpleadosDepartamento(int IdDept)
        {
            List<Empleado>? empleados = await repositoryHospital.GetDepartamentosByDept(IdDept!);
            return View(empleados);
        }

        public async Task<IActionResult> Pagiando(int posicion)
        {
            if (posicion == 0)
            {
                posicion = 1;
            }

            int numeroPagina = 1;
            int numeroRegistros = await repositoryHospital.GetCountVistaEmpleadosAsync();
            string html = "";
            for (int i = 0; i < numeroRegistros; i += 2)
            {
                html += "<li class='page-item'><a class='page-link' href='Empleados/Pagiando/?posicion=" + posicion + "'>Pagina " + i + "</a></li>";
            }
            ViewData["LINKS"] = html;

            VistaDepartamento? departamento = await repositoryHospital.GetVistaDepartamentoAsync(posicion);
            return View(departamento);
        }

        public async Task<IActionResult> PaginarEmpleados(int? posicion)
        {
            if (!posicion.HasValue)
            {
                posicion = 1;
            }

            int forward = posicion.Value + 1;
            int backward = posicion.Value - 1;
            if (backward <= 0)
            {
                backward = 1;
            }

            ViewData["BACKWARD"] = backward;
            ViewData["ACTUAL"] = posicion;
            ViewData["FORWARD"] = forward;

            List<Empleado>? empleados = await repositoryHospital.GetListEmpleadosAsync(posicion.Value * 4);
            return View(empleados);
        }

    }
}
