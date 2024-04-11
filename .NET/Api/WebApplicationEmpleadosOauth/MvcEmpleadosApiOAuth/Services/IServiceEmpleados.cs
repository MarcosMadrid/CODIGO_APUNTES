using WebApplicationEmpleadosOauth.Models;

namespace MvcEmpleadosApiOAuth.Services
{
    public interface IServiceEmpleados
    {
        Task<string?> GetToken(string username, string password);
        Task<T?> GetApiResponse<T>(string request);
        Task<T?> GetApiResponse<T>(string request, string token);
        Task<List<Empleado>?> GetEmpleados();
        Task<Empleado?> GetEmpleado(int id, string token);
    }
}
