using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace AdoNet.Repositories
{
    public class RepositoryParamSalida
    {
        SqlConnection sqlConnection;
        SqlDataReader sqlDataReader;

        public RepositoryParamSalida()
        {
            this.sqlConnection = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;Persist Security Info=True;User ID=SA;Password=MCSD2023;");
        }

        public List<String> LoadDept()
        {
            List<String> list = new List<String>();
            SqlCommand cmd = this.sqlConnection.CreateCommand();
            cmd.CommandText = "SP_DEPARTAMENTOS";
            sqlConnection.Open();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader["DNOMBRE"].ToString());
            }
            sqlConnection.Close();
            return list;
        }

        public ResumenEmpleados GetResumenEmpleados(string nombre_dept)
        {
            ResumenEmpleados res = new ResumenEmpleados();
            SqlCommand sqlCommand = this.sqlConnection.CreateCommand();
            sqlCommand.CommandText = "";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@NOMBRE", nombre_dept);
            sqlCommand.Parameters.Add(parameter);

            SqlParameter sumaSalario = new SqlParameter("@SUMASALARIO", SqlDbType.Int);
            sumaSalario.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sumaSalario);

            SqlParameter mediaSalario = new SqlParameter("@MEDIASALARIO", SqlDbType.Int);
            mediaSalario.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(mediaSalario);

            SqlParameter personasCount = new SqlParameter("@PERSONAS", SqlDbType.Int);
            personasCount.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(personasCount);

            sqlConnection.Open();
            sqlDataReader = sqlCommand.ExecuteReader();
            List<string> apellidos = new List<string>();
            while (sqlDataReader.Read())
            {
                apellidos.Add(sqlDataReader["APELLIDOS"].ToString());
            }
            res.Apellidos = apellidos;

            res.MediaSalarial = (int)mediaSalario.Value;
            res.SumaSalarial = (int)sumaSalario.Value;
            res.TotalPersonas = (int)personasCount.Value;

            return res;
        }
    }
}
