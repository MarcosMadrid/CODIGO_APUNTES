using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreEnfermosEF.Data;
using MvcCoreEnfermosEF.Models;
using System.Data;
using System.Data.Common;

#region PROCEDIMIENTOS ALMACENADOS
//create procedure SP_TODOS_ENFERMOS
//as
//    select* from ENFERMO
//go
//create procedure SP_FIND_ENFERMO
//(@inscripcion int)
//as
//    select* from ENFERMO
//    where INSCRIPCION=@inscripcion
//go
//create procedure SP_DELETE_ENFERMO
//(@inscripcion int)
//as
//    delete from ENFERMO
//    where INSCRIPCION=@inscripcion
//go
#endregion

namespace MvcCoreEnfermosEF.Repositories
{
    public class EnfermoRepository
    {
        private readonly HospitalBBDDContext context;

        public EnfermoRepository(HospitalBBDDContext context)
        {
            this.context = context;
        }

        public List<Enfermo> GetEnfermos()
        {
            List<Enfermo> enfermos = new List<Enfermo>();

            using (DbCommand command =
                this.context.Database.GetDbConnection().CreateCommand())
            {
                string sql = "SP_TODOS_ENFERMOS";
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();

                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Enfermo enfermo = new Enfermo
                    {
                        Inscripcion = reader["INSCRIPCION"].ToString(),
                        Apellido = reader["APELLIDO"].ToString(),
                        NSS = reader["NSS"].ToString(),
                        GeneroBioogico = reader["S"].ToString(),
                        Direccion = reader["DIRECCION"].ToString(),
                        Fecha_Nac = DateTime.Parse(reader["FECHA_NAC"].ToString())
                    };
                    enfermos.Add(enfermo);
                }
                reader.Close();
                command.Connection.Close();

                return enfermos;
            }
        }

        public Enfermo? GetEnfermo(string id)
        {
            Enfermo? enfermo;
            string sql = "SP_FIND_ENFERMO @inscripcion";
            SqlParameter sqlInscripcion = new SqlParameter("@inscripcion", id);

            var consulta = this.context.Enfermos.FromSqlRaw(sql, sqlInscripcion);
            enfermo = consulta.AsEnumerable().FirstOrDefault();

            return enfermo;
        }

        public void DeleteEnfermo(string id)
        {
            string sql = "SP_DELETE_ENFERMO @inscripcion";
            SqlParameter sqlParameter = new SqlParameter("inscripcion", id);
            this.context.Database.ExecuteSqlRaw(sql, sqlParameter);
        }

        public void InsertEnfermo(string apellido, string nss, string s, string direccion, DateTime fecha_nac)
        {
            string sql = "PD_MAX_ID_ENFERMO @apellido ,@direccion ,@fecha_nac ,@s ,@nss";

            SqlParameter sqlParameter = new SqlParameter("apellido", apellido);
            SqlParameter sqlDirecion = new SqlParameter("direccion", direccion);
            SqlParameter sqlFecha = new SqlParameter("fecha_nac", fecha_nac);
            SqlParameter sqlGenero = new SqlParameter("s", s);
            SqlParameter sqlNss = new SqlParameter("nss", nss);

            this.context.Database.ExecuteSqlRaw(sql, sqlParameter, sqlDirecion, sqlFecha, sqlGenero, sqlNss);
        }

    }
}