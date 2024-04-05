using ApiHospitalesNet.Models;
using ApiHospitalesNet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHospitalesNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalesController : ControllerBase
    {
        private RepositoryHospital repository;
        public HospitalesController(RepositoryHospital repositoryHospital)
        {
            repository = repositoryHospital;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hospital>>> GetHospitales()
        {
            return
                await repository.GetHospitales();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital?>> GetHospital(int id)
        {
            return
                await repository.GetHospital(id);
        }
    }
}
