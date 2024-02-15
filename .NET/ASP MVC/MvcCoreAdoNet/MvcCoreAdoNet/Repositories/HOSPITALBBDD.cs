using MvcCoreAdoNet.Models;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace MvcCoreAdoNet.Repositories
{
    public class HOSPITALBBDDConnector
    {
        SqlConnection _connection;
        SqlDataReader _reader;

        public HOSPITALBBDDConnector()
        {
            string connectionString = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;Persist Security Info=True;User ID=SA;Password=MCSD2023;";
            _connection = new SqlConnection(connectionString);
        }

        public List<Hospital> GetHospitales()
        {
            List<Hospital> hospitals = new List<Hospital>();
            string sql = "SELECT * FROM HOSPITAL";
            SqlCommand sqlCommand = new SqlCommand(sql, _connection);

            _connection.Open();
            _reader = sqlCommand.ExecuteReader();
            while (_reader.Read())
            {
                Hospital hospital = new Hospital();

                hospital.IdHospital = int.Parse(_reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = _reader["Nombre"].ToString();
                hospital.Telefono = _reader["Telefono"].ToString();
                hospital.Direccion = _reader["Direccion"].ToString();
                hospital.Camas = int.Parse(_reader["NUM_CAMA"].ToString());

                hospitals.Add(hospital);
            }
            _connection.Close();
            return hospitals;
        }

        public Hospital GetHospital(string idHospital)
        {
            string sql = "SELECT * FROM HOSPITAL WHERE @HOSPITAL_COD = HOSPITAL_COD";
            SqlCommand sqlCommand = new SqlCommand(sql, _connection);
            SqlParameter parameter = new SqlParameter("HOSPITAL_COD", idHospital);
            sqlCommand.Parameters.Add(parameter);

            _connection.Open();
            _reader = sqlCommand.ExecuteReader();
            Hospital hospital = new Hospital();
            while (_reader.Read())
            {
                hospital.IdHospital = int.Parse(_reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = _reader["Nombre"].ToString();
                hospital.Telefono = _reader["Telefono"].ToString();
                hospital.Direccion = _reader["Direccion"].ToString();
                hospital.Camas = int.Parse(_reader["NUM_CAMA"].ToString());
            }
            _connection.Close();
            return hospital;
        }


        public void InsertHospital(Hospital hospital)
        {
            string sql = "INSERT INTO HOSPITAL VALUES (@idhospital , @nombre , @direccion , @telefono, @camas)";
            SqlParameter idHospital = new SqlParameter("idhospital", hospital.IdHospital);
            SqlParameter nombre = new SqlParameter("nombre", hospital.Nombre);
            SqlParameter direccion = new SqlParameter("direccion", hospital.Direccion);
            SqlParameter telefono = new SqlParameter("telefono", hospital.Telefono);
            SqlParameter camas = new SqlParameter("camas", hospital.Camas);

            SqlCommand sqlCommand = _connection.CreateCommand();
            sqlCommand.Parameters.Add(idHospital);
            sqlCommand.Parameters.Add(nombre);
            sqlCommand.Parameters.Add(direccion);
            sqlCommand.Parameters.Add(telefono);
            sqlCommand.Parameters.Add(camas);

            sqlCommand.CommandText = sql;
            _connection.Open();
            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }

        public void DeleteHospital(string idHospital)
        {
            string sql = "DELETE FROM HOSPITAL WHERE HOSPITAL_COD=@idhospital";
            SqlCommand sqlCommand = _connection.CreateCommand();
            sqlCommand.CommandText = sql;

            sqlCommand.Parameters.AddWithValue("idhospital", idHospital);

            _connection.Open();
            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }

        public void UpdateHospital(Hospital hospital)
        {
            string sql = "UPDATE HOSPITAL SET NOMBRE=@nombre , DIRECCION=@direccion , TELEFONO=@telefono, NUM_CAMA=@camas " +
                "WHERE HOSPITAL_COD=@idhospital";
            SqlCommand sqlCommand = _connection.CreateCommand();
            sqlCommand.CommandText = sql;

            sqlCommand.Parameters.AddWithValue("idhospital", hospital.IdHospital);
            sqlCommand.Parameters.AddWithValue("nombre", hospital.Nombre);
            sqlCommand.Parameters.AddWithValue("direccion", hospital.Direccion);
            sqlCommand.Parameters.AddWithValue("telefono", hospital.Telefono);
            sqlCommand.Parameters.AddWithValue("camas", hospital.Camas);

            _connection.Open();
            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }

    }
}

