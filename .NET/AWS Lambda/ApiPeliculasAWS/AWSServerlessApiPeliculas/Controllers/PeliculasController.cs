using AWSServerlessApiPeliculas.Models;
using AWSServerlessApiPeliculas.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerlessApiPeliculas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private RepositoryPelicula repositoryPelicula;
        public PeliculasController(RepositoryPelicula repositoryPelicula)
        {
            this.repositoryPelicula = repositoryPelicula;
        }

        // GET: api/<PeliculasController>
        [HttpGet]
        public async Task<List<Pelicula>> Get()
        {
            List<Pelicula> peliculas = new List<Pelicula>();
            peliculas = await repositoryPelicula.GetPeliculas();
            return peliculas;
        }

        // GET api/<PeliculasController>/5
        [HttpGet("{id}")]
        public async Task<Pelicula?> GetPelicula(int id)
        {
            Pelicula? pelicula = new Pelicula();
            pelicula = await repositoryPelicula.GetPelicula(id);
            return pelicula;
        }

        // POST api/<PeliculasController>
        [HttpPost]
        public async Task<Pelicula> Post([FromBody] Pelicula pelicula)
        {
            pelicula = await this.repositoryPelicula.PostPelicula
                (pelicula.Genero, pelicula.Titulo, pelicula.Argumento, pelicula.Foto, pelicula.Actores, pelicula.Precio, pelicula.Youtube);
            return pelicula;
        }

        // PUT api/<PeliculasController>/5
        [HttpPut("{id}")]
        public async Task<Pelicula?> Put([FromBody] Pelicula pelicula)
        {
            pelicula = await this.repositoryPelicula.PutPelicula
                (pelicula.IdPelicula, pelicula.Genero, pelicula.Titulo, pelicula.Argumento, pelicula.Foto, pelicula.Actores, pelicula.Precio, pelicula.Youtube);
            return pelicula;
        }

        // DELETE api/<PeliculasController>/5
        [HttpDelete("{id}")]
        public async Task<Pelicula?> Delete(int id)
        {
            return
                await repositoryPelicula.DeleePelicula(id);
        }
    }
}
