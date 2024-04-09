using ApiCrudCoreDoctores.Models;
using ApiCrudCoreDoctores.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudCoreDoctores.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private IRepositoryDoct repositoryDoctores;

        public DoctoresController(IRepositoryDoct repositoryDoctores)
        {
            this.repositoryDoctores = repositoryDoctores;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>?>> GetDoctores()
        {
            return
                await repositoryDoctores.GetDoctores();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor?>> GetDoctor(int id)
        {
            return
                await repositoryDoctores.GetDoctor(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            try
            {
                await repositoryDoctores.DeleteDoctor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{idHospital}/{idDoctor}/{apellido}/{especialidad}/{salario}")]
        public async Task<ActionResult> DeleteDoctor(int idHospital, int idDoctor, string apellido, string especialidad, int salario)
        {
            try
            {
                await repositoryDoctores.PutDoctor(idHospital, idDoctor, apellido, especialidad, salario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutDoctor(Doctor doctor)
        {
            try
            {
                await repositoryDoctores.PutDoctor(doctor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
