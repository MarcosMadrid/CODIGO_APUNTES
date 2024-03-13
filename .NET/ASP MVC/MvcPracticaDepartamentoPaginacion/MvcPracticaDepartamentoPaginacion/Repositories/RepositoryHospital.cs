using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcPracticaDepartamentoPaginacion.Data;
using MvcPracticaDepartamentoPaginacion.Models;
using System.Data;

namespace MvcPracticaDepartamentoPaginacion.Repositories
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

        public async Task<List<Empleado>?> GetListEmpleadosAsync(int posicion)
        {
            string sql = "SP_GRUPOS_EMPLEADOS @POSICION";
            SqlParameter sqlPosicion = new SqlParameter("POSICION", posicion);

            return
                await context.Empleados.FromSqlRaw(sql, sqlPosicion).ToListAsync();
        }

        public async Task<List<Empleado>?> GetEmpleadosDeptPaginaAsync(int posicion, int range, int dept_no)
        {
            int maxCount = -1;
            string sql = "SP_EMPLEADOS_DEPARTAMENTO_PAGINA @POSICION, @DEPT_NO, @RANGE, @MAX_COUNT";
            SqlParameter sqlPosicion = new SqlParameter("POSICION", posicion);
            SqlParameter sqlDeptNo = new SqlParameter("DEPT_NO", dept_no);
            SqlParameter sqlRange = new SqlParameter("RANGE", range);
            
            SqlParameter sqlMaxCount = new SqlParameter("MAX_COUNT", maxCount);
            sqlMaxCount.Direction = ParameterDirection.Output;

            return
                await context.Empleados.FromSqlRaw(sql, sqlPosicion, sqlDeptNo, sqlRange, sqlMaxCount).ToListAsync();
        }


    }
}
