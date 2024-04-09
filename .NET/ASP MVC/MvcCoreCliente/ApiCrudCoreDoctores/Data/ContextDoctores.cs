using ApiCrudCoreDoctores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudCoreDoctores.Data
{
    public class ContextDoctores : DbContext
    {
        public ContextDoctores(DbContextOptions<ContextDoctores> options) : base(options) { }
        public DbSet<Doctor> Doctores { get; set; }
    }
}
