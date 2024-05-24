using Microsoft.EntityFrameworkCore;
using AWSServerlessApiCrudPersonajesAWS.Models;

namespace AWSServerlessApiCrudPersonajesAWS.Data
{
    public class ApiPersonajesAWSContext : DbContext
    {
        public ApiPersonajesAWSContext (DbContextOptions<ApiPersonajesAWSContext> options)
            : base(options)
        {
        }

        public DbSet<Personaje> Personaje { get; set; } = default!;
    }
}
