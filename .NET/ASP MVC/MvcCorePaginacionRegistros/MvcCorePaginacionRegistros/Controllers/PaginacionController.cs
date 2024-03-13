using Microsoft.AspNetCore.Mvc;
using MvcCorePaginacionRegistros.Models;
using MvcCorePaginacionRegistros.Repositories;

namespace MvcCorePaginacionRegistros.Controllers
{
    public class PaginacionController : Controller
    {
        RepositoryHospital repositoryHospital;

        public PaginacionController(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public async Task<IActionResult> PaginarRegistroVistaDepartamento(int id)
        {
            if (id == 0)
            {
                id = 1;
            }
            int forward = id + 1;
            int numeroRegistros = await repositoryHospital.GetCountVistaEmpleadosAsync();
            if (forward > numeroRegistros)
            {
                forward = numeroRegistros;
            }
            int backward = id - 1;
            if (backward < 1)
            {
                backward = 1;
            }
            VistaDepartamento? departamento = await repositoryHospital.GetVistaDepartamentoAsync(id);
            ViewData["ACTUAL"] = id;
            ViewData["LAST"] = numeroRegistros;
            ViewData["FORWARD"] = forward;
            ViewData["BACKWARD"] = backward;

            return RedirectToAction("EmpleadosDepartamento", "Empleados", new { Id = departamento!.Id });
        }
    }
}
