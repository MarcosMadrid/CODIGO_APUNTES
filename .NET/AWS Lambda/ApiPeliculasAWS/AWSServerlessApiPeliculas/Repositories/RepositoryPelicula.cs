using AWSServerlessApiPeliculas.Data;
using AWSServerlessApiPeliculas.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSServerlessApiPeliculas.Repositories
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
                .Where(p => p.Actores!.Contains(actor))
                .ToListAsync();
        }

        public async Task<List<Pelicula>> GetPeliculas()
        {
            return
                await context.Peliculas.ToListAsync();
        }

        public async Task<Pelicula?> GetPelicula(int idPelicula)
        {
            return
                await context.Peliculas
                .FirstOrDefaultAsync(p => p.IdPelicula.Equals(idPelicula));
        }

        private async Task<int> GetMaxIdPelicula()
        {
            return
                await context.Peliculas
                .MaxAsync(p => p.IdPelicula);
        }

        public async Task<Pelicula> PostPelicula(string genero, string titulo, string argumento, string foto, string actores, int precio, string youtube)
        {
            Pelicula pelicula = new Pelicula()
            {
                IdPelicula = await this.GetMaxIdPelicula() + 1,
                Titulo = titulo,
                Actores = actores,
                Genero = genero,
                Argumento = argumento,
                Foto = foto,
                Precio = precio,
                Youtube = youtube
            };

            this.context.Peliculas.Add(pelicula);
            await context.SaveChangesAsync();
            return pelicula;
        }

        public async Task<Pelicula?> PutPelicula(int id, string genero, string titulo, string argumento, string foto, string actores, int precio, string youtube)
        {
            Pelicula? pelicula = await this.GetPelicula(id);
            if (pelicula is null)
            {
                return null;
            }

            pelicula.Titulo = titulo;
            pelicula.Actores = actores;
            pelicula.Genero = genero;
            pelicula.Argumento = argumento;
            pelicula.Foto = foto;
            pelicula.Precio = precio;
            pelicula.Youtube = youtube;

            await context.SaveChangesAsync();
            return pelicula;
        }

        public async Task<Pelicula?> DeleePelicula(int id)
        {
            Pelicula? pelicula = await this.GetPelicula(id);
            context.Peliculas.Remove(pelicula);
            await this.context.SaveChangesAsync();
            return pelicula;
        }
    }
}
