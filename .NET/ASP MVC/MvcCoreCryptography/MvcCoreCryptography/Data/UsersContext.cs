using Microsoft.EntityFrameworkCore;
using MvcCoreCryptography.Models;

namespace MvcCoreCryptography.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
