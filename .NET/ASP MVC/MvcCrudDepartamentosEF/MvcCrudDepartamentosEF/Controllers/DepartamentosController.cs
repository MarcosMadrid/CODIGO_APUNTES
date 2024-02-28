using Microsoft.AspNetCore.Mvc;
using MvcCrudDepartamentosEF.Models;
using MvcCrudDepartamentosEF.Repositories;

namespace MvcCrudDepartamentosEF.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamento repositoryDepartamento;

        public DepartamentosController(RepositoryDepartamento repository)
        {
            this.repositoryDepartamento = repository;
        }

        public IActionResult Index()
        {
            List<Departamento>? departamentos = repositoryDepartamento.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int id)
        {
            Departamento? departamento = repositoryDepartamento.GetDepartamento(id);
            return View(departamento);
        }

        public IActionResult Delete(int id)
        {
            repositoryDepartamento.DeleteDepartamento(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateForm(int id)
        {
            Departamento? departamento = repositoryDepartamento.GetDepartamento(id);
            return View("UpdateForm", departamento);
        }

        [HttpPost]
        public IActionResult Edit(Departamento departamento)
        {
            repositoryDepartamento.UpdateDepartamento(departamento.Id, departamento.Name, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult InsertForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Departamento departamento)
        {
            repositoryDepartamento.InsertDepartamento(departamento.Id, departamento.Name, departamento.Localidad);
            return RedirectToAction("Index");
        }

    }
}
