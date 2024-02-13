using MvcCoreLinqToSql.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreLinqToSql.Repositories
{
    public class RepositoryEnfermos
    {
        private SqlConnection sqlConnection = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;User ID=SA;Password=MCSD2023;");
        private DataTable tableEnfermos = new DataTable();
        private SqlCommand sqlCommand;

        public RepositoryEnfermos()
        {
            string sql = "SELECT * FROM ENFERMO";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnection);
            adapter.Fill(tableEnfermos);

            sqlCommand = sqlConnection.CreateCommand();
        }

        public List<Enfermo>? GetEnfermosList()
        {
            List<Enfermo> enfermos = new List<Enfermo>();

            enfermos = tableEnfermos.AsEnumerable()
                .Select(enfermoRow =>
                    {
                        Enfermo enfermo = new Enfermo();

                        enfermo.INSCRIPCION = enfermoRow.Field<string>("INSCRIPCION");
                        enfermo.DIRECCION = enfermoRow.Field<string>("DIRECCION");
                        enfermo.APELLIDO = enfermoRow.Field<string>("APELLIDO");
                        enfermo.FECHA_NAC = enfermoRow.Field<DateTime>("FECHA_NAC");
                        enfermo.S = enfermoRow.Field<string>("S");
                        enfermo.NSS = enfermoRow.Field<string>("NSS");

                        return enfermo;
                    })
                .ToList();

            if (enfermos.Count() == 0)
            {
                return null;
            }
            return enfermos;
        }

        public async Task DeleteEnfermoAsync(string idEnfermo)
        {
            string sql = "DELETE FROM ENFERMO WHERE INSCRIPCION = @IDENFERMO";

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("IDENFERMO", idEnfermo);
            sqlCommand.CommandText = sql;

            await sqlConnection.OpenAsync();
            await sqlCommand.ExecuteNonQueryAsync();
            await sqlConnection.CloseAsync();

            sqlCommand.Parameters.Clear();
        }

        public Enfermo? GetEnfermo(string idEnfermo)
        {
            var enfermoSearch = (from enfermoRow in tableEnfermos.AsEnumerable()
                                 where enfermoRow.Field<string>("INSCRIPCION") == idEnfermo
                                 select enfermoRow)
                                .First();

            if (enfermoSearch is null)
            {
                return null;
            }

            Enfermo enfermo = new Enfermo();
            enfermo.INSCRIPCION = enfermoSearch.Field<string?>("INSCRIPCION");
            enfermo.DIRECCION = enfermoSearch.Field<string?>("DIRECCION");
            enfermo.APELLIDO = enfermoSearch.Field<string?>("APELLIDO");
            enfermo.S = enfermoSearch.Field<string?>("S");
            enfermo.NSS = enfermoSearch.Field<string?>("NSS");
            enfermo.FECHA_NAC = enfermoSearch.Field<DateTime?>("FECHA_NAC");

            return enfermo;
        }
    }
}
