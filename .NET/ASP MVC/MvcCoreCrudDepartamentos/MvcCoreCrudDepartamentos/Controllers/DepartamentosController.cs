using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudDepartamentos.Models;
using MvcCoreCrudDepartamentos.Repositories;

namespace MvcCoreCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        RepositoryDept RepositoryDept = new RepositoryDept();
        List<Departamento> departamentos = new List<Departamento>();

        public IActionResult DepartamentosTable()
        {
            departamentos = RepositoryDept.GetDepartamentosAsync().Result;
            return View(departamentos);
        }

        public async Task<IActionResult> DepartamentoDetalles(int idDept)
        {
            var departamento = await RepositoryDept.FindDepartamentoAsync(idDept);
            return View(departamento);
        }

        [HttpGet]
        public IActionResult DepartamentoForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DepartamentoForm(Departamento? departamento)
        {
            if (departamento == null)
            {
                return View();
            }
            else
            {
                await RepositoryDept.CreateDepartamentoAsync(departamento.DNOMBRE, departamento.LOC);
                return RedirectToAction("DepartamentosTable");
            }
        }

        public async Task<IActionResult> DepartamentoDelete(int idDept)
        {
            await RepositoryDept.DeleteDepartamentoAsync(idDept);
            return RedirectToAction("DepartamentosTable");
        }

        [HttpPut]
        public async Task<IActionResult> DepartamentoUpdate(Departamento departamento)
        {
            await RepositoryDept.UpdateDepartamento(departamento.DEPT_NO, departamento.DNOMBRE, departamento.LOC);
            return RedirectToAction("DepartamentosTable");
        }
    }
}
