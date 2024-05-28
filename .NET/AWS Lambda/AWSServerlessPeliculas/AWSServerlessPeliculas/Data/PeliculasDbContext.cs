using AWSServerlessPeliculas.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSServerlessPeliculas.Data
{
    public class PeliculasDbContext : DbContext
    {
        public PeliculasDbContext(DbContextOptions<PeliculasDbContext> options) : base(options) { }

        public DbSet<Pelicula> Peliculas { get; set; }
    }
}
