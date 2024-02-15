using NetCoreLinqToSqlInjection.Models;

namespace NetCoreLinqToSqlInjection.Repositories
{
    public interface IRepositoryBBDDConnectorDocotres
    {
        Task<Doctor> GetDoctorAsync(string id);
        List<Doctor>? GetDoctors();
        List<Doctor>? GetDoctorsEspecialidad(string especialidad);
        void InsertDoctor(string id, string apellido, string especialidad, int salario, string idHospital);
        void DeleteDoctor(string id);
        List<string?>? GetEspecialidadesDoctores();
    }
}
