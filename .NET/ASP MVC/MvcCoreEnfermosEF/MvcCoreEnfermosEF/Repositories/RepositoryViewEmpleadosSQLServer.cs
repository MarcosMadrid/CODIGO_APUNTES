using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreEnfermosEF.Data;
using MvcCoreEnfermosEF.Models;

namespace MvcCoreEnfermosEF.Repositories
{
    public class RepositoryViewEmpleadosSQLServer : IRepoitoryHospital
    {
        private readonly HospitalBBDDContext context;

        public RepositoryViewEmpleadosSQLServer(HospitalBBDDContext context)
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
            string sql = "SP_DETAILS_EMPLEADO @IDEMPLEADO";
            SqlParameter sqlId = new SqlParameter("@IDEMPLEADO", id);
            var consulta = await context.ViewEmpleados
                                .FromSqlRaw(sql, sqlId)
                                .ToListAsync();

            return consulta.FirstOrDefault();
        }

    }
}
