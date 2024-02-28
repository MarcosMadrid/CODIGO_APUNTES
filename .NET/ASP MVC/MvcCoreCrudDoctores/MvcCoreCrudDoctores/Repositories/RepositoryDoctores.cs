using Microsoft.Data.SqlClient;
using MvcCoreCrudDoctores.Models;
using System.Numerics;

namespace MvcCoreCrudDoctores.Repositories
{
    public class RepositoryDoctores
    {
        SqlConnection _connection = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;User ID=SA;Password=1234;Encrypt=True;Trust Server Certificate=True");
        SqlCommand _command;
        SqlDataReader _reader;
        public RepositoryDoctores()
        {
            _command = _connection.CreateCommand();
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            List<Doctor> result = new List<Doctor>();

            string sql = "SELECT * FROM DOCTOR";
            _command.Parameters.Clear();
            _command.CommandText = sql;

            await _connection.OpenAsync();
            _reader = await _command.ExecuteReaderAsync();
            while (_reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.HOSPITAL_COD = _reader["HOSPITAL_COD"].ToString();
                doctor.DOCTOR_NO = _reader["DOCTOR_NO"].ToString();
                doctor.APELLIDO = _reader["APELLIDO"].ToString();
                doctor.ESPECIALIDAD = _reader["ESPECIALIDAD"].ToString();
                doctor.SALARIO = int.Parse(_reader["SALARIO"].ToString());

                result.Add(doctor);
            }
            await _reader.CloseAsync();
            await _connection.CloseAsync();
            _command.Parameters.Clear();

            return result;
        }

        public async Task<Doctor?> GetDoctorAsync(string idDoctor)
        {
            Doctor? doctor = null;

            string sql = "SELECT * FROM DOCTOR WHERE DOCTOR_NO = @ID";
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("ID", idDoctor);
            _command.CommandText = sql;

            await _connection.OpenAsync();
            _reader = await _command.ExecuteReaderAsync();
            while (_reader.Read())
            {
                doctor = new Doctor();
                doctor.HOSPITAL_COD = _reader["HOSPITAL_COD"].ToString();
                doctor.DOCTOR_NO = _reader["DOCTOR_NO"].ToString();
                doctor.APELLIDO = _reader["APELLIDO"].ToString();
                doctor.ESPECIALIDAD = _reader["ESPECIALIDAD"].ToString();
                doctor.SALARIO = int.Parse(_reader["SALARIO"].ToString());
            }
            await _reader.CloseAsync();
            await _connection.CloseAsync();
            _command.Parameters.Clear();

            return doctor;
        }

        public async Task DeleteDoctor(string idDocotor)
        {
            string sql = "DELETE FROM DOCTOR WHERE DOCTOR_NO = @ID";
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("ID", idDocotor);
            _command.CommandText = sql;

            await _connection.OpenAsync();
            await _command.ExecuteNonQueryAsync();
            await _connection.CloseAsync();
            _command.Parameters.Clear();

            return;
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            string sql = "UPDATE DOCTOR SET HOSPITAL_COD=@HOSPITAL_COD, APELLIDO=@APELLIDO, ESPECIALIDAD=@ESPECIALIDAD, SALARIO=@SALARIO " +
                " WHERE DOCTOR_NO = @DOCTOR_NO ;";
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("HOSPITAL_COD", doctor.HOSPITAL_COD);
            _command.Parameters.AddWithValue("DOCTOR_NO", doctor.DOCTOR_NO);
            _command.Parameters.AddWithValue("APELLIDO", doctor.APELLIDO);
            _command.Parameters.AddWithValue("ESPECIALIDAD", doctor.ESPECIALIDAD);
            _command.Parameters.AddWithValue("SALARIO", doctor.SALARIO);

            _command.CommandText = sql;

            await _connection.OpenAsync();
            await _command.ExecuteNonQueryAsync();
            await _connection.CloseAsync();
            _command.Parameters.Clear();

            return;
        }

        public async Task InsertDoctor(Doctor doctor)
        {
            string sql = "INSERT INTO DOCTOR VALUES " +
                "(@HOSPITAL_COD, @DOCTOR_NO, " +
                " @APELLIDO, @ESPECIALIDAD, @SALARIO) ;";
            _command.Parameters.Clear();
            _command.Parameters.AddWithValue("HOSPITAL_COD", doctor.HOSPITAL_COD);
            _command.Parameters.AddWithValue("DOCTOR_NO", doctor.DOCTOR_NO);
            _command.Parameters.AddWithValue("APELLIDO", doctor.APELLIDO);
            _command.Parameters.AddWithValue("ESPECIALIDAD", doctor.ESPECIALIDAD);
            _command.Parameters.AddWithValue("SALARIO", doctor.SALARIO);

            _command.CommandText = sql;

            await _connection.OpenAsync();
            await _command.ExecuteNonQueryAsync();
            await _connection.CloseAsync();
            _command.Parameters.Clear();

            return;
        }
    }
}
