using MvcCoreEnfermosEF.Models;

namespace MvcCoreEnfermosEF.Repositories
{
    public interface IRepoitoryHospital
    {
        Task<List<ViewEmpleado>> GetViewEmpleadosAsync();
        Task<ViewEmpleado?> GetEmpleadoAsync(int id);

    }
}
