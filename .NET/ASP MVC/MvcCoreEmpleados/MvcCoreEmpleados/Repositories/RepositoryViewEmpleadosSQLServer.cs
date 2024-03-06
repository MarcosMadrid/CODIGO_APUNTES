using Microsoft.EntityFrameworkCore;
using MvcCoreEmpleados.Data;
using MvcCoreEmpleados.Models;
using NuGet.Packaging.Signing;

namespace MvcCoreEmpleados.Repositories
{
    public class RepositoryViewEmpleadosSQLServer
    {
        private readonly HospitalBBDDContext context;

        public RepositoryViewEmpleadosSQLServer(HospitalBBDDContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            var consulta = context.Empleados.ToListAsync();

            return await consulta;
        }

        public async Task<List<Empleado>> GetEmpleadosByIdsAsync(List<int> ids)
        {
            var consulta = context.Empleados.Where(
                    empleado => ids.Contains(empleado.IdEmpleado)
                )
                .ToListAsync();
            return await consulta;
        }

        public async Task<List<Empleado>?> GetEmpleadosNoIdsAsync(List<int> ids)
        {
            var consulta = context.Empleados.Where(
                    empleado => !ids.Contains(empleado.IdEmpleado)
                )
                .ToListAsync();
            return await consulta;
        }

        public async Task<Empleado?> GetEmpleadoAsync(int id)
        {
            var consulta = context.Empleados.FirstOrDefaultAsync(
                    empleado => id.Equals(empleado.IdEmpleado)
                );
            return await consulta;
        }
    }
}
