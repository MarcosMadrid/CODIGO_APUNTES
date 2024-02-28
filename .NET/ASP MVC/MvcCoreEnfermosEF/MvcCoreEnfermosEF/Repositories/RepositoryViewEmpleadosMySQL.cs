using Microsoft.EntityFrameworkCore;
using MvcCoreEnfermosEF.Data;
using MvcCoreEnfermosEF.Models;
using MySqlConnector;

namespace MvcCoreEnfermosEF.Repositories
{
    public class RepositoryViewEmpleadosMySQL : IRepoitoryHospital
    {
        private readonly HospitalBBDDContext context;

        public RepositoryViewEmpleadosMySQL(HospitalBBDDContext context)
        {
            this.context = context;
        }

        public async Task<ViewEmpleado?> GetEmpleadoAsync(int id)
        {
            string sql = "CALL sp_empleado_view(@p_idempleado)";
            MySqlParameter sqlId = new MySqlParameter("p_idempleado", id);
            var consulta = await context.ViewEmpleados.FromSqlRaw(sql, sqlId).ToListAsync();

            return consulta.FirstOrDefault();
        }

        public async Task<List<ViewEmpleado>> GetViewEmpleadosAsync()
        {
            string sql = "CALL sp_empleados_view";
            var consulta = context.ViewEmpleados.FromSqlRaw(sql);

            return await consulta.ToListAsync();
        }
    }
}
