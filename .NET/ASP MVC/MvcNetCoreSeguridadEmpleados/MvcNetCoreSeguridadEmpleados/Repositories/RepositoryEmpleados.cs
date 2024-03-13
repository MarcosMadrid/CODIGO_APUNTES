using Microsoft.EntityFrameworkCore;
using MvcNetCoreSeguridadEmpleados.Data;
using MvcNetCoreSeguridadEmpleados.Models;

namespace MvcNetCoreSeguridadEmpleados.Repositories
{
    public class RepositoryEmpleados
    {
        EmpleadosContext empleados;
        public RepositoryEmpleados(EmpleadosContext empleados)
        {
            this.empleados = empleados;
        }

        public async Task<List<Empleado>?> GetEmpleadosAsync()
        {
            return
                await empleados.Empleados.ToListAsync();
        }

        public async Task<Empleado?> GetEmpleadoAsync(int id)
        {
            return
                await empleados.Empleados.FirstOrDefaultAsync(emp => emp.Id.Equals(id));
        }

        public async Task<Empleado?> GetEmpleadoAsync(string apellido, int id)
        {
            return
                await empleados.Empleados.FirstOrDefaultAsync(emp => emp.Id.Equals(id) && emp.Apellido.Equals(apellido));
        }

        public async Task<List<Empleado>> GetEmpleadosDepartamentoAsync(int id_dept)
        {
            return
                await empleados.Empleados
                    .Where(empleados => empleados.IdDepart.Equals(id_dept))
                    .ToListAsync();
        }

        public async Task UpdateSalarioEmpleadosDepartamentoAsync(int id_dept, int incremento)
        {
            await empleados.Empleados.Where(emp => emp.IdDepart == id_dept)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(emp => emp.Salario, emp => emp.Salario + incremento)
                );
        }

        public async Task<Empleado?> ValidarUser(string apellido, int idEmpleado)
        {
            return await empleados.Empleados
                .FirstOrDefaultAsync(emp => emp.Id == idEmpleado && emp.Apellido!.Equals(apellido));
        }
    }
}
