using Microsoft.EntityFrameworkCore;
using WebApplicationEmpleadosOauth.Data;
using WebApplicationEmpleadosOauth.Models;

namespace WebApplicationEmpleadosOauth.Repositories
{
    public class RepositoryHospital
    {
        HospitalContext hospitalContext;

        public RepositoryHospital(HospitalContext hospitalContext)
        {
            this.hospitalContext = hospitalContext;
        }

        public async Task<List<Empleado>?> GetEmpleados()
        {
            return
                await hospitalContext.Empleados.ToListAsync();
        }

        public async Task<List<Empleado>?> GetEmpleadosDept(int idDept)
        {
            return 
                await hospitalContext.Empleados
                    .Where(emp => emp.IdDept.Equals(idDept))
                    .ToListAsync();
        }

        public async Task<Empleado?> GetEmpleado(int id)
        {
            return
                await hospitalContext.Empleados.FirstOrDefaultAsync(emp => emp.Id.Equals(id));
        }

        public async Task<Empleado?> LogInEmp(int id, string apellido)
        {
            return
                await hospitalContext.Empleados
                .Where(emp =>

                    emp.Id.Equals(id) && emp.Apellido.Equals(apellido)
                ).
                FirstOrDefaultAsync();
        }
    }
}
