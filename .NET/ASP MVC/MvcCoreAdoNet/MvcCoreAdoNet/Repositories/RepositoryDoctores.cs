using MvcCoreAdoNet.Models;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryDoctores
    {
        SqlConnection _sqlConnector;
        SqlCommand cmd;
        SqlDataReader reader;

        public RepositoryDoctores()
        {
            _sqlConnector = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;Persist Security Info=True;User ID=SA;Password=MCSD2023;");
            cmd = _sqlConnector.CreateCommand();
        }

        public List<Doctor> GetDoctores()
        {
            List<Doctor> doctors = new List<Doctor>();

            cmd.Parameters.Clear();
            string sql = "SELECT* FROM DOCTOR";
            cmd.CommandText = sql;


            _sqlConnector.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Doctor doctor = new Doctor();

                doctor.HOSPITAL_COD = reader["HOSPITAL_COD"].ToString();
                doctor.DOCTOR_NO = reader["DOCTOR_NO"].ToString();
                doctor.APELLIDO = reader["APELLIDO"].ToString();
                doctor.ESPECIALIDAD = reader["ESPECIALIDAD"].ToString();
                doctor.SALARIO = int.Parse(reader["SALARIO"].ToString());

                doctors.Add(doctor);
            }
            _sqlConnector.Close();

            return doctors;
        }

        public List<string> GetEspecialidadesDoctores()
        {
            List<string> especialidades = new List<string>();

            string sql = "SELECT DISTINCT(ESPECIALIDAD) FROM DOCTOR";
            cmd.Parameters.Clear();
            cmd.CommandText = sql;

            _sqlConnector.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string especialidad = reader["ESPECIALIDAD"].ToString();
                especialidades.Add(especialidad);
            }
            _sqlConnector.Close();
            cmd.Parameters.Clear();

            return especialidades;
        }

        public List<Doctor> GetDoctoresEspecialidad(string especialidad)
        {
            List<Doctor> doctors = new List<Doctor>();

            string sql = "SELECT * FROM DOCTOR WHERE ESPECIALIDAD = @ESPECIALIDAD";
            cmd.Parameters.Clear();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("ESPECIALIDAD", especialidad);

            _sqlConnector.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Doctor doctor = new Doctor();

                doctor.HOSPITAL_COD = reader["HOSPITAL_COD"].ToString();
                doctor.DOCTOR_NO = reader["DOCTOR_NO"].ToString();
                doctor.APELLIDO = reader["APELLIDO"].ToString();
                doctor.ESPECIALIDAD = reader["ESPECIALIDAD"].ToString();
                doctor.SALARIO = int.Parse(reader["SALARIO"].ToString());

                doctors.Add(doctor);
            }
            _sqlConnector.Close();
            cmd.Parameters.Clear();

            return doctors;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            string sql = "UPDATE DOCTOR SET HOSPITAL_COD=@HOSPITAL_COD, DOCTOR_NO=@DOCTOR_NO, APELLIDO=@APELLIDO, ESPECIALIDAD=@ESPECIALIDAD, SALARIO=@SALARIO" +
                " WHERE DOCTOR_NO=@DOCTOR_NO";
            cmd.CommandText = sql;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("HOSPITAL_COD", doctor.HOSPITAL_COD);
            cmd.Parameters.AddWithValue("DOCTOR_NO", doctor.DOCTOR_NO);
            cmd.Parameters.AddWithValue("APELLIDO", doctor.APELLIDO);
            cmd.Parameters.AddWithValue("ESPECIALIDAD", doctor.ESPECIALIDAD);
            cmd.Parameters.AddWithValue("SALARIO", doctor.SALARIO);

            _sqlConnector.Open();
            cmd.ExecuteNonQuery();
            _sqlConnector.Close();
            cmd.Parameters.Clear();
        }

    }
}
