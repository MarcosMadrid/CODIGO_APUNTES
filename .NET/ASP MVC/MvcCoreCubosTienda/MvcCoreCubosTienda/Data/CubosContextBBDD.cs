using Microsoft.EntityFrameworkCore;
using MvcCoreCubosTienda.Models;

namespace MvcCoreCubosTienda.Data
{
    public class CubosContextBBDD : DbContext
    {
        public CubosContextBBDD(DbContextOptions<CubosContextBBDD> options) : base(options){ }

        public DbSet<Cubo> Cubos { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}
