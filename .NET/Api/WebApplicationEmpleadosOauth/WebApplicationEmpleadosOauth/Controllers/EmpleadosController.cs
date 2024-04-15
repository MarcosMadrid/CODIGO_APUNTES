using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
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
        [HttpGet]
        public ActionResult<Empleado?> GetProfile()
        {
            try
            {
                Claim? claim = User.FindFirst(claim => claim.Type == "UserData");
                if (claim == null)
                {
                    return NoContent();
                }
                else
                {
                    Empleado emp = JsonConvert.DeserializeObject<Empleado>(claim.Value)!;
                    return Ok(emp);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Empleado>?>> GetEmpleadosDeptUser()
        {
            try
            {
                string userData = User.FindFirst(claim => claim.Type == "UserData")!.Value;
                Empleado empleado = JsonConvert.DeserializeObject<Empleado>(userData)!;
                List<Empleado>? empleados = await repositoryHospital.GetEmpleadosDept(empleado.IdDept);
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
