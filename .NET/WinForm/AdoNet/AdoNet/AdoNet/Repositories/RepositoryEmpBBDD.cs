using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Repositories
{
    public class RepositoryEmpBBDD
    {
        private SqlConnection sqlConnection;
        private SqlDataReader sqlDataReader;

        public RepositoryEmpBBDD()
        {
            this.sqlConnection = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;Persist Security Info=True;User ID=SA;Password=MCSD2023;");
        }

        public List<Empleado> GetEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            string sql = "SELECT * FROM EMP";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);

            sqlConnection.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Empleado emp = new Empleado();
                emp.APELLIDO = sqlDataReader["APELLIDO"].ToString();
                emp.OFICIO = sqlDataReader["OFICIO"].ToString();
                emp.SALARIO = (int)sqlDataReader["SALARIO"];
                emp.COMISION = (int)sqlDataReader["COMISION"];
                empleados.Add(emp);
            }
            sqlConnection.Close();
            return empleados;
        }

        public void UpdateSalarioEmps(string oficio, int salario)
        {
            string sql = "UPDATE EMP SET SALARIO = SALARIO + @SALARIO WHERE OFICIO = @OFICIO";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

            SqlParameter parameter = new SqlParameter("SALARIO", salario);
            sqlCommand.Parameters.Add(parameter);
            parameter = new SqlParameter("OFICIO", oficio);
            sqlCommand.Parameters.Add(parameter);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }
    }
}
