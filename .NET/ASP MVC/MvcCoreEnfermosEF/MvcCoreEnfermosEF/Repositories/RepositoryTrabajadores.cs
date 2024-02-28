using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreEnfermosEF.Data;
using MvcCoreEnfermosEF.Models;
using System.Data;
using System.Threading.Tasks;

namespace MvcCoreEnfermosEF.Repositories
{
    public class RepositoryTrabajadores
    {
        private readonly HospitalBBDDContext context;

        public RepositoryTrabajadores(HospitalBBDDContext hospitalBBDDContext)
        {
            context = hospitalBBDDContext;
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = context.Trabajadores.Select(trabajador => trabajador.Oficio).Distinct().ToListAsync();
            return await consulta;
        }

        public async Task<TrabajadoresModel> GetTrabajadoresModelAsync(string oficio)
        {
            TrabajadoresModel trabajadoresModel = new TrabajadoresModel();
            string sql = "SP_TRABAJOS_OFICIO @oficio, @personas OUT, @media OUT, @suma OUT ";

            SqlParameter pamOficio = new SqlParameter("oficio", oficio);
            SqlParameter pamPersonas = new SqlParameter("personas", -1);
            SqlParameter pamMedia = new SqlParameter("media", -1);
            SqlParameter pamTotal = new SqlParameter("suma", -1);

            pamPersonas.Direction = ParameterDirection.Output;
            pamMedia.Direction = ParameterDirection.Output;
            pamTotal.Direction = ParameterDirection.Output;

            var consulta = context.Trabajadores.FromSqlRaw(sql, pamOficio, pamPersonas, pamMedia, pamTotal);

            trabajadoresModel.TrabajadorList = await consulta.ToListAsync();
            trabajadoresModel.Personas = (int.Parse(pamPersonas.Value.ToString()));
            trabajadoresModel.SumaSalarial = (int.Parse(pamTotal.Value.ToString()));
            trabajadoresModel.MediaSalarial = (int.Parse(pamMedia.Value.ToString()));

            return trabajadoresModel;
        }
    }
}
