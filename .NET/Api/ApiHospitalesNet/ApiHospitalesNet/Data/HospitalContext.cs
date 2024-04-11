using ApiHospitalesNet.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiHospitalesNet.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }
        public DbSet<Hospital> Hospitales { get; set; }
    }
}
