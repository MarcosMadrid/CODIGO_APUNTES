using Microsoft.AspNetCore.Mvc;
using MvcPracticaDepartamentoPaginacion.Models;
using MvcPracticaDepartamentoPaginacion.Repositories;
using MvcPracticaDepartamentoPaginacion.ViewComponents;
using System.Text.Json;

namespace MvcPracticaDepartamentoPaginacion.Controllers
{
    public class HomeController : Controller
    {
        RepositoryHospital repositoryHospital;

        public HomeController(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public async Task<IActionResult> Index(int? dept_no, int? posicion)
        {
            if (posicion != null)
            {
                TempData["ACTUAL"] = posicion;
            }
            else
            {
                TempData["ACTUAL"] = 1;
            }
            List<Departamento> departamentos = await repositoryHospital.GetDepartamentos();
            if (dept_no != null)
            {
                Departamento? departamento = departamentos.FirstOrDefault(dept => dept.Id == dept_no);
                if (departamento != null)
                {
                    TempData["DEPT_NO"] = JsonSerializer.Serialize<Departamento>(departamento!);
                }
            }
            return View(departamentos);
        }

        public async Task<IActionResult> EmpleadoViewComponent(int posicion, int? dept_no)
        {
            if (posicion != null)
            {
                TempData["ACTUAL"] = posicion;
            }
            else
            {
                TempData["ACTUAL"] = 1;
            }
            List<Departamento> departamentos = await repositoryHospital.GetDepartamentos();
            if (dept_no != null)
            {
                Departamento? departamento = departamentos.FirstOrDefault(dept => dept.Id == dept_no);
                if (departamento != null)
                {
                    TempData["DEPT_NO"] = JsonSerializer.Serialize<Departamento>(departamento!);
                }
            }
            var viewComponent = new DetailsEmpleadoViewComponent(repositoryHospital);
            var result =  viewComponent.View();

            // Return the view component result
            return result;
        }
    }
}
