using Microsoft.AspNetCore.Mvc;
using MvcCorePaginacionRegistros.Models;
using MvcCorePaginacionRegistros.Repositories;

namespace MvcCorePaginacionRegistros.ViewComponents
{
    public class DepartamentosNavViewComponent : ViewComponent
    {
        private RepositoryHospital repositoryHospital;
        public DepartamentosNavViewComponent(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Departamento>? departamentos = await repositoryHospital.GetDepartamentos();
            return View(departamentos);
        }
    }
}
