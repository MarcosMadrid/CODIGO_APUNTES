using Microsoft.EntityFrameworkCore;
using MvcCoreEnfermosEF.Data;
using MvcCoreEnfermosEF.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlTypes;

namespace MvcCoreEnfermosEF.Repositories
{
    public class RepositoryEmpleadosViewOracle : IRepoitoryHospital
    {
        private readonly HospitalBBDDContext context;

        public RepositoryEmpleadosViewOracle(HospitalBBDDContext context)
        {
            this.context = context;
        }

        public async Task<List<ViewEmpleado>> GetViewEmpleadosAsync()
        {
            var consulta = context.ViewEmpleados.ToListAsync();

            return await consulta;
        }

        public async Task<ViewEmpleado?> GetEmpleadoAsync(int id)
        {
            string sql = "begin ";
            sql += " SP_DETAILS_EMPLEADO (:p_cursor_empleados, :IDEMPLEADO);";
            sql += " end;";
            OracleParameter pamCursor = new OracleParameter();
            pamCursor.ParameterName = "p_cursor_empleados";
            pamCursor.Value = null;
            pamCursor.Direction = ParameterDirection.Output;
            pamCursor.OracleDbType = OracleDbType.RefCursor;

            OracleParameter pamId = new OracleParameter("IDEMPLEADO", id);

            var consulta = await this.context.ViewEmpleados.FromSqlRaw(sql, pamCursor ,pamId).ToListAsync();
            
            return consulta.FirstOrDefault();
        }
    }
}
