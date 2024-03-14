using NetCoreSeguridadDoctores.Models;

namespace NetCoreSeguridadDoctores.Repositories
{
    public interface IRepositoryHospital
    {
        Task<Doctor?> GetDoctor(string apellido, string idDoctor);
        Task<Enfermo?> GetEnfermo(string nss);
        Task<List<Enfermo>?> GetEnfermos();
        Task<Boolean> DeleteEnfermo(string nss);
    }
}
