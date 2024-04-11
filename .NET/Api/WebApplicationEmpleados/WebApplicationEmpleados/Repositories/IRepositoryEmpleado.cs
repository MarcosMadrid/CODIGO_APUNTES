using WebApplicationEmpleados.Models;

namespace WebApplicationEmpleados.Repositories
{
    public interface IRepositoryEmpleado
    {
        Task<List<Empleado>?> GetEmpleados();
        Task<Empleado?> GetEmpleado(int idEmpleado);
        Task<List<Empleado>?> GetEmpleadosOficio(string oficio);
        Task<List<string?>?> GetOficiosAsync();
        Task<List<Empleado>?> GetEmpleadoSalario(int salario, int idDepartamento);
    }
}
