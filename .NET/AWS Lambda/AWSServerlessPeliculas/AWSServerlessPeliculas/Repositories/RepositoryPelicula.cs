using AWSServerlessPeliculas.Data;
using AWSServerlessPeliculas.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSServerlessPeliculas.Repositories
{
    public class RepositoryPelicula
    {
        private PeliculasDbContext context;

        public RepositoryPelicula(PeliculasDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Pelicula>> GetPeliculasActor(string actor)
        {
            return
                await context.Peliculas
                .Where(p => p.Actores.Contains(actor))
                .ToListAsync();
        }



        public async Task<List<Pelicula>> GetPeliculas()
        {
            return
                await context.Peliculas.ToListAsync();
        }
    }
}
