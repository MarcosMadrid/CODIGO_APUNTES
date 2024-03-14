using Microsoft.EntityFrameworkCore;
using NetCoreSeguridadDoctores.Data;
using NetCoreSeguridadDoctores.Models;

namespace NetCoreSeguridadDoctores.Repositories
{
    public class RepositoryHospitalSqlServer : IRepositoryHospital
    {
        HospitalContext hospitalContext;

        public RepositoryHospitalSqlServer(HospitalContext hospital)
        {
            hospitalContext = hospital;
        }

        public async Task<bool> DeleteEnfermo(string nss)
        {
            Enfermo? enfermo = await hospitalContext.Enfermos.FirstOrDefaultAsync(enf => enf.NSS.Equals(nss));
            if (enfermo == null)
            {
                return false;
            }
            try
            {
                var consulta = hospitalContext.Enfermos.Remove(enfermo);
                await hospitalContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Doctor?> GetDoctor(string apellido, string idDoctor)
        {
            return
                await hospitalContext.Doctores.FirstOrDefaultAsync(doc => doc.Apellido.Equals(apellido) && doc.Id == idDoctor);
        }

        public async Task<Enfermo?> GetEnfermo(string nss)
        {
            return
                 await hospitalContext.Enfermos.FirstOrDefaultAsync(enf => enf.NSS.Equals(nss));
        }

        public async Task<List<Enfermo>?> GetEnfermos()
        {
            return
                await hospitalContext.Enfermos.ToListAsync();
        }
    }
}
