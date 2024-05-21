using Microsoft.EntityFrameworkCore;
using WebApplicationAWS.Models;

namespace WebApplicationAWS.Data
{
    public class ContextDept : DbContext
    {
        public ContextDept(DbContextOptions<ContextDept> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
