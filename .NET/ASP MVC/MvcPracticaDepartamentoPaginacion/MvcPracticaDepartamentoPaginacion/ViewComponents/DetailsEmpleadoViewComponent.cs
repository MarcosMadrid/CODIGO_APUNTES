using Microsoft.AspNetCore.Mvc;
using MvcPracticaDepartamentoPaginacion.Models;
using MvcPracticaDepartamentoPaginacion.Repositories;
using System.Text.Json;

namespace MvcPracticaDepartamentoPaginacion.ViewComponents
{
    public class DetailsEmpleadoViewComponent : ViewComponent
    {
        RepositoryHospital repositoryHospital;
        public DetailsEmpleadoViewComponent(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int? posicion = int.Parse(TempData["ACTUAL"]!.ToString()!);
            int range = 1;
            if (posicion == null)
            {
                posicion = 1;
            }

            TempData["BACK"] = posicion - 1;
            if (posicion - 1 <= 0)
            {
                TempData["BACK"] = 1;
            }

            TempData["NEXT"] = posicion + 1;
            TempData["RANGE"] = range;
            List<Empleado>? empleados = new List<Empleado>();

            string? JsonDept= TempData["DEPT_NO"]?.ToString();

            if (JsonDept != null)
            {
                Departamento departamento = JsonSerializer.Deserialize<Departamento>(JsonDept)!;
                empleados = await repositoryHospital.GetEmpleadosDeptPaginaAsync(posicion: posicion.Value , range: range, dept_no: departamento.Id);
            }

            return View(empleados);
        }

    }
}
