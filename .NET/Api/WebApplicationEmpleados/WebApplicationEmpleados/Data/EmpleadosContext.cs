using Microsoft.EntityFrameworkCore;
using WebApplicationEmpleados.Models;

namespace WebApplicationEmpleados.Data
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
