using MvcCoreAdoNet.Models;
using System.Data.SqlClient;

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

    }
}

