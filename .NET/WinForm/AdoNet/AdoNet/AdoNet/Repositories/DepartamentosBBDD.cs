using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Repositories
{
    public class DepartamentosBBDD
    {
        private SqlConnection sqlConnection;
        SqlCommand Command;
        private SqlDataReader Reader;

        public DepartamentosBBDD()
        {
            string connectionString = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;Persist Security Info=True;User ID=SA;Password=MCSD2023;";
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Departamento> GetDepartamentosBBDD()
        {
            List<Departamento> list_dept = new List<Departamento>();
            string sql = "SELECT * FROM DEPT";
            Command = new SqlCommand(sql, sqlConnection);
            this.sqlConnection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Departamento dept = new Departamento();
                foreach (var property in dept.GetType().GetProperties())
                {
                    var propertyValue = Reader[property.Name];
                    if (propertyValue != null)
                    {
                        property.SetValue(dept, propertyValue);
                    }
                }
                list_dept.Add(dept);
            }
            sqlConnection.Close();
            return list_dept;
        }

        public Departamento GetDepartamentoBBDD(Departamento dept)
        {
            string sql = "SELECT * FROM DEPT WHERE DEPT.DEPT_NO = @DEPT_NO";
            Command = new SqlCommand(sql, sqlConnection);
            Command.Parameters.Add(new SqlParameter("DEPT_NO", dept.DEPT_NO));
            this.sqlConnection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                foreach (var property in dept.GetType().GetProperties())
                {
                    var propertyValue = Reader[property.Name];
                    if (propertyValue != null)
                    {
                        property.SetValue(dept, propertyValue);
                    }
                }
            }
            sqlConnection.Close();
            return dept;
        }

        public void UpdateDepartamentosBBDD(List<Departamento> list_dept)
        {
            string sql = "";
            foreach (var dept in list_dept)
            {
                sql += "UPDATE DEPT SET ";
                foreach (var property in dept.GetType().GetProperties())
                {
                    sql += " DEPT." + property.Name + " = " + property.Name + ",";
                }
                sql = sql.TrimEnd(' ', ',');
                sql += " WHERE DEPT.DEPT_NO = "+ dept.DEPT_NO +"; \n";
            }
            Command = new SqlCommand(sql, sqlConnection);

            this.sqlConnection.Open();
            Command.ExecuteReader();
            this.sqlConnection.Close();
        }

        public void UpdateDepartamentoBBDD(Departamento dept, int dept_no)
        {
            string sql = "";
            Command = new SqlCommand();

            sql += "UPDATE DEPT SET ";
            foreach (var property in dept.GetType().GetProperties())
            {
                sql += " DEPT." + property.Name + " = @" + property.Name + " ,";
                SqlParameter parameter = new SqlParameter(property.Name, property.GetValue(dept));
                Command.Parameters.Add(parameter);
            }
            sql = sql.TrimEnd(' ', ',');
            sql += " WHERE DEPT.DEPT_NO = @DEPT_NO_ACTUAL ;";
            Command.Parameters.Add(new SqlParameter("DEPT_NO_ACTUAL", dept_no));

            Command.CommandText = sql;
            Command.Connection = this.sqlConnection;

            this.sqlConnection.Open();
            var hola = Command.ExecuteReader();
            this.sqlConnection.Close();
        }

        public void InsertDepartamentoBBDD(Departamento dept)
        {
            string sql = "";
            Command = sqlConnection.CreateCommand();

            sql += "INSERT INTO DEPT (";
            foreach (var property in dept.GetType().GetProperties())
            {
                sql += " " + property.Name + " ,";
            }
            sql = sql.TrimEnd(' ', ',');
            sql += ") VALUES (";

            foreach (var property in dept.GetType().GetProperties())
            {
                sql += " @" + property.Name + " ,";
                SqlParameter parameter = new SqlParameter(property.Name, property.GetValue(dept));
                Command.Parameters.Add(parameter);
            }
            sql = sql.TrimEnd(' ', ',');
            sql += ") ;";

            Command.CommandText = sql;

            this.sqlConnection.Open();
            Command.ExecuteReader();
            this.sqlConnection.Close();
        }
    }
}
