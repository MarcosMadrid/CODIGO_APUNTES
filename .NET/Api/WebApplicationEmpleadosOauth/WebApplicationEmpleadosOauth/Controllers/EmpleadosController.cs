using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEmpleadosOauth.Models;
using WebApplicationEmpleadosOauth.Repositories;

namespace WebApplicationEmpleadosOauth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        RepositoryHospital repositoryHospital;

        public EmpleadosController(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>?>> GetEmpleados()
        {
            return
                await repositoryHospital.GetEmpleados();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado?>> GetEmpleado(int id)
        {
            return
                await repositoryHospital.GetEmpleado(id);
        }
    }
}
