using Microsoft.EntityFrameworkCore;
using MvcCoreEmpleados.Models;

namespace MvcCoreEmpleados.Data
{
    public class HospitalBBDDContext : DbContext
    {
        public HospitalBBDDContext(DbContextOptions<HospitalBBDDContext> options) : base(options)
        { }
        public DbSet<Empleado> Empleados { get; set; }

    }
}
