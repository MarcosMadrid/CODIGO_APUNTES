using ApiHospitalesNet.Data;
using ApiHospitalesNet.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiHospitalesNet.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Hospital>> GetHospitales()
        {
            return
                await context.Hospitales.ToListAsync();
        }

        public async Task<Hospital?> GetHospital(int id)
        {
            return
                await context.Hospitales.FirstOrDefaultAsync(hosp => hosp.Id.Equals(id));
        }
    }
}
