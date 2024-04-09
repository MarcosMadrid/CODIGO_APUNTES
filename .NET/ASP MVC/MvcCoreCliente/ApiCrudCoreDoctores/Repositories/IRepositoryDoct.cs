using ApiCrudCoreDoctores.Models;

namespace ApiCrudCoreDoctores.Repositories
{
    public interface IRepositoryDoct
    {
        Task<Doctor?> GetDoctor(int id);
        Task<List<Doctor>?> GetDoctores();
        Task DeleteDoctor(int id);
        Task PutDoctor(Doctor doctor);
        Task PostDoctor(Doctor doctor);
        Task PutDoctor(int idHospital, int idDoctor, string apellido, string especialidad, int salario);
        Task PostDoctor(int idHospital, string apellido, string especialidad, int salario);
    }
}
