using Microsoft.Data.SqlClient;
using MvcCoreCrudDepartamentos.Models;
using System.Data;

namespace MvcCoreCrudDepartamentos.Repositories
{
    public class RepositoryDept
    {
        SqlConnection _connection;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader _reader;
        public RepositoryDept()
        {
            _connection = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;User ID=SA;Password=MCSD2023;Encrypt=True;Trust Server Certificate=True");
            cmd.Connection = _connection;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            List<Departamento> departamentos = new List<Departamento>();
            string sql = "SELECT * FROM DEPT ;";

            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;

            await _connection.OpenAsync();
            _reader = await cmd.ExecuteReaderAsync();
            while (_reader.Read())
            {
                Departamento departamento = new Departamento();
                departamento.DEPT_NO = int.Parse(_reader["DEPT_NO"].ToString());
                departamento.DNOMBRE = _reader["DNOMBRE"].ToString();
                departamento.LOC = _reader["LOC"].ToString();

                departamentos.Add(departamento);
            }
            _reader.Close();
            _connection.Close();

            return departamentos;
        }

        public async Task<Departamento?> FindDepartamentoAsync(int idDept)
        {
            Departamento? departamento = null;
            string sql = "SELECT * FROM DEPT WHERE DEPT_NO = @id ;";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("id", idDept);
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            await _connection.OpenAsync();
            _reader = await cmd.ExecuteReaderAsync();
            if (await _reader.ReadAsync())
            {
                departamento = new Departamento();
                departamento.DEPT_NO = int.Parse(_reader["DEPT_NO"].ToString());
                departamento.DNOMBRE = _reader["DNOMBRE"].ToString();
                departamento.LOC = _reader["LOC"].ToString();
            }
            else
            {
                return null;
            }
            await _reader.CloseAsync();
            await _connection.CloseAsync();
            cmd.Parameters.Clear();

            return departamento;
        }

        public async Task CreateDepartamentoAsync(string dnombre, string localidad)
        {
            string sql = "SP_INSERTDEPARTAMENTO";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("NOMBRE", dnombre);
            cmd.Parameters.AddWithValue("LOCALIDAD", localidad);
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;

            await _connection.OpenAsync();
            _reader = await cmd.ExecuteReaderAsync();
            await _connection.CloseAsync();
            cmd.Parameters.Clear();
        }

        public async Task DeleteDepartamentoAsync(int idDept)
        {
            string sql = "DELETE FROM DEPT WHERE DEPT_NO = @ID_DEPT";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("ID_DEPT", idDept);
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            await _connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await _connection.CloseAsync();

            cmd.Parameters.Clear();
        }

        public async Task UpdateDepartamento(int idDept, string nombre, string localidad)
        {
            string sql = "UPDATE DEPT SET DNOMBRE=@DNOMBRE, LOC=@LOACLIDAD, DEPT_NO = @ID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("DNOMBRE", nombre);
            cmd.Parameters.AddWithValue("LOCALIDAD", localidad);
            cmd.Parameters.AddWithValue("ID", idDept);
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            await _connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await _connection.CloseAsync();

            cmd.Parameters.Clear();
        }
    }
}
