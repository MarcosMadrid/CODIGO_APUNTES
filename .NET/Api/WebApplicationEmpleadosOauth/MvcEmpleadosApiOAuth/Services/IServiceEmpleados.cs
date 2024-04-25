using WebApplicationEmpleadosOauth.Models;

namespace MvcEmpleadosApiOAuth.Services
{
    public interface IServiceEmpleados
    {
        Task<string?> GetToken(string username, string password);
        Task<T?> GetApiResponse<T>(string request);
        Task<List<Empleado>?> GetEmpleados();
        Task<Empleado?> GetEmpleado(int id);
        Task<Empleado?> GetPerfil();
        Task<List<Empleado>?> GetEmpleadosDeptUser();
    }
}
