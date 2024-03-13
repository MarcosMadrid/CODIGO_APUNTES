using Microsoft.AspNetCore.Mvc;
using MvcCorePaginacionRegistros.Models;
using MvcCorePaginacionRegistros.Repositories;

namespace MvcCorePaginacionRegistros.ViewComponents
{
    public class PaginationNavDeptViewComponent : ViewComponent
    {

        RepositoryHospital repositoryHospital;

        public PaginationNavDeptViewComponent(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public async Task<IViewComponentResult> InvokeAsync(int IdDept)
        {
            if (IdDept == 0)
            {
                IdDept = 1;
            }
            int forward = IdDept + 1;
            int numeroRegistros = await repositoryHospital.GetCountVistaEmpleadosAsync();
            if (forward > numeroRegistros)
            {
                forward = numeroRegistros;
            }
            int backward = IdDept - 1;
            if (backward < 1)
            {
                backward = 1;
            }
            VistaDepartamento? departamento = await repositoryHospital.GetVistaDepartamentoAsync(IdDept);
            ViewData["ACTUAL"] = IdDept;
            ViewData["LAST"] = numeroRegistros;
            ViewData["FORWARD"] = forward;
            ViewData["BACKWARD"] = backward;

            return View(departamento);
        }
    }
}
