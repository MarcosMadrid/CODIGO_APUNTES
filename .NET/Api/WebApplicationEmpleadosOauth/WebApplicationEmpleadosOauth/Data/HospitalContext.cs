using Microsoft.EntityFrameworkCore;
using WebApplicationEmpleadosOauth.Models;

namespace WebApplicationEmpleadosOauth.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
