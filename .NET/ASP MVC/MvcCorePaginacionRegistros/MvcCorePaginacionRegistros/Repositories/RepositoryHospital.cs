using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCorePaginacionRegistros.Data;
using MvcCorePaginacionRegistros.Models;

namespace MvcCorePaginacionRegistros.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentos()
        {
            return await context.Departamentos.ToListAsync();
        }

        public async Task<List<Empleado>> GetDepartamentosByDept(int IdDept)
        {
            return await context.Empleados.Where(emp => emp.IdDepartamento.Equals(IdDept)).ToListAsync();
        }

        public async Task<VistaDepartamento?> GetVistaDepartamentoAsync(int posicion)
        {
            return await context.vistaDepartamentos.FirstOrDefaultAsync(dept => dept.Posicion.Equals(posicion));
        }

        public async Task<int> GetCountVistaEmpleadosAsync()
        {
            return await context.vistaDepartamentos.CountAsync();
        }

        public async Task<List<Empleado>?> GetListEmpleadosAsync(int posicion)
        {
            string sql = "SP_GRUPOS_EMPLEADOS @POSICION";
            SqlParameter sqlPosicion = new SqlParameter("POSICION", posicion);

            return
                await context.Empleados.FromSqlRaw(sql, sqlPosicion).ToListAsync();
        }




    }
}
