using Microsoft.EntityFrameworkCore;
using MvcEntityFrameWorkComics.Models;

namespace MvcEntityFrameWorkComics.Data
{
    public class ComicBBDDContext : DbContext
    {
        public ComicBBDDContext(DbContextOptions<ComicBBDDContext> options) : base(options) { }

        public DbSet<Comic> Comics { get; set; }
    }
}

