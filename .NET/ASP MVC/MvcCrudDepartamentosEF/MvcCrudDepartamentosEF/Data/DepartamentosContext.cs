using Microsoft.EntityFrameworkCore;
using MvcCrudDepartamentosEF.Models;

namespace MvcCrudDepartamentosEF.Data
{
    public class DepartamentosContext : DbContext
    {
        public DepartamentosContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Departamento> Departamento { get; set; }
    }
}
