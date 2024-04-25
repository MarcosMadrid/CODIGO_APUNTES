using Microsoft.AspNetCore.Mvc;
using WebApplicationEmpleados.Models;
using WebApplicationEmpleados.Repositories;

namespace WebApplicationEmpleados.Controllers
{
    [Route("data/[action]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private IRepositoryEmpleado repositoryEmpleado;
        public EmpleadosController(IRepositoryEmpleado repositoryEmpleado)
        {
            this.repositoryEmpleado = repositoryEmpleado;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>?>> GetEmpleados()
        {
            return
                await repositoryEmpleado.GetEmpleados();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado?>> GetEmpleado(int id)
        {
            return
                await repositoryEmpleado.GetEmpleado(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<string?>?>> GetOficios()
        {
            return
                await repositoryEmpleado.GetOficiosAsync();
        }

        [HttpGet]
        [Route("{oficio}")]
        public async Task<ActionResult<List<Empleado>?>> GetEmpleadosOficio(string oficio)
        {
            return
                await repositoryEmpleado.GetEmpleadosOficio(oficio);
        }

        [HttpGet]
        [Route("{salario}/{iddepartamento}")]
        public async Task<ActionResult<List<Empleado>?>> GetEmpleadosSalario(int salario, int iddepartamento)
        {
            return
                await repositoryEmpleado.GetEmpleadoSalario(salario, iddepartamento);
        }
    }
}
