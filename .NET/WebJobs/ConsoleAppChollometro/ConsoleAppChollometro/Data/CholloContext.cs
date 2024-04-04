using ConsoleAppChollometro.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppChollometro.Data
{
    public class CholloContext : DbContext
    {
        public CholloContext(DbContextOptions<CholloContext> options)
            : base(options) { }

        public DbSet<Chollo> Chollos { get; set; }
    }
}