using ApiCorePersonas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCorePersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        List<Persona> personaList;

        public PersonasController()
        {
            personaList = new List<Persona>
                {
                    new Persona { Id = 1, Name = "John Doe", Email = "john@example.com", Age = 30 },
                    new Persona { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Age = 25 },
                    new Persona { Id = 3, Name = "Michael Johnson", Email = "michael@example.com", Age = 40 },
                    new Persona { Id = 4, Name = "Emily Brown", Email = "emily@example.com", Age = 35 },
                    new Persona { Id = 5, Name = "David Lee", Email = "david@example.com", Age = 28 },
                    new Persona { Id = 6, Name = "Sarah Williams", Email = "sarah@example.com", Age = 32 },
                    new Persona { Id = 7, Name = "Chris Wilson", Email = "chris@example.com", Age = 45 }
                };
        }

        [HttpGet]
        public ActionResult<List<Persona>> GetPersonas()
        {
            return this.personaList;
        }


        [HttpGet("{id}")]
        public ActionResult<Persona> GetPersona(int id)
        {
            return personaList.FirstOrDefault(persona => persona.Id.Equals(id));
        }
    }
}
