using Microsoft.EntityFrameworkCore;
using MvcNetCoreSeguridadEmpleados.Models;

namespace MvcNetCoreSeguridadEmpleados.Data
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
