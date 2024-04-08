using Microsoft.EntityFrameworkCore;
using WebApplicationEmpleados.Data;
using WebApplicationEmpleados.Models;

namespace WebApplicationEmpleados.Repositories
{
    public class RepositoryEmpleadoSqlServer : IRepositoryEmpleado
    {
        private EmpleadosContext context;
        public RepositoryEmpleadoSqlServer(EmpleadosContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>?> GetEmpleados()
        {
            return
                await context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> GetEmpleado(int idEmpleado)
        {
            return
                await context.Empleados.FirstOrDefaultAsync(empleado => empleado.Id.Equals(idEmpleado));
        }

        public async Task<List<Empleado>?> GetEmpleadosOficio(string oficio)
        {
            return
                await context.Empleados.Where(empleado => empleado.Oficio.Equals(oficio)).ToListAsync();
        }

        public async Task<List<string?>?> GetOficiosAsync()
        {
            return
                await context.Empleados.Select(empleado => empleado.Oficio).Distinct().ToListAsync();
        }

        public async Task<List<Empleado>?> GetEmpleadoSalario(int salario, int idDepartamento)
        {
            return
                await context.Empleados.Where(empleado => empleado.Salario.Equals(salario) && empleado.IdDepartamento.Equals(idDepartamento)).ToListAsync();
        }
    }
}
