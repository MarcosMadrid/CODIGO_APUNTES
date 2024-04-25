using ApiCoreCrudDepartamentos.Models;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentos.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentos()
        {
            return await this.repo.GetDepartamentosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            return await this.repo.GetDepartamentoAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> PostDepartamento(Departamento departamento)
        {
            await this.repo.InsertDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            if (await this.repo.GetDepartamentoAsync(id) == null)
            {
                return NotFound();
            }
            else
            {
                await this.repo.DeleteDepartamentoAsync(id);
                return Ok();
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutDepartamento(Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/{nombre}/{localidad}")]
        public async Task<ActionResult> CreateDepartamento(int id, string nombre, string localidad)
        {
            await this.repo.InsertDepartamentoAsync(id, nombre, localidad);
            return Ok();
        }

        [HttpPut]
        [Route("{id}/{nombre}/{localidad}")]
        public async Task<ActionResult> UpdateDepartamento(int id, string nombre, string localidad)
        {
            await this.repo.UpdateDepartamentoAsync(id, nombre, localidad);
            return Ok();
        }
    }
}
