using Microsoft.EntityFrameworkCore;
using MvcCoreSeries.Models;

namespace MvcCoreSeries.Data
{
    public class TelevisionDbContext : DbContext
    {
        public TelevisionDbContext(DbContextOptions<TelevisionDbContext> options) : base(options) { }

        public DbSet<Serie> Series { get; set; }
    }
}
