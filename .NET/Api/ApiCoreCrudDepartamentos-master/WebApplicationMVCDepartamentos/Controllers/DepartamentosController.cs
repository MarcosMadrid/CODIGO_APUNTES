using ApiCoreCrudDepartamentos.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVCDepartamentos.Services;

namespace WebApplicationMVCDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {

        ServiceDepartamentos serviceDepartamentos;

        public DepartamentosController(ServiceDepartamentos service)
        {
            serviceDepartamentos = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento>? depts = await serviceDepartamentos.GetDepartamentosAsync();
            return View(depts);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento? dept = await serviceDepartamentos.GetDepartamentoAsync(id);
            return View(dept);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Departamento? dept = await serviceDepartamentos.GetDepartamentoAsync(id);
            return View(dept);
        }
        
        public async Task<IActionResult> Edit(Departamento departamento)
        {
            await serviceDepartamentos.PutDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await serviceDepartamentos.DeleteDepartamento(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create(Departamento departamento)
        {
            await serviceDepartamentos.PutDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TableDept()
        {
            List<Departamento>? depts = await serviceDepartamentos.GetDepartamentosAsync();
            return PartialView("_TableDept", depts);
        }
    }
}
