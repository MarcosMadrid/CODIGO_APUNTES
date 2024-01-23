using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Repositories
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

        public List<string> GetTablesNames()
        {
            _connection.Open();
            DataTable tables = _connection.GetSchema("Tables");

            List<string> TableNames = new List<string>();
            foreach (DataRow row in tables.Rows)
            {
                TableNames.Add(row[2].ToString());
            }
            _connection.Close();
            return TableNames;
        }

        public DataTable GetTableContent(string table_name)
        {
            DataTable Content = new DataTable();
            string sql = "SELECT * FROM " + table_name;
            SqlCommand sqlCommand = new SqlCommand(sql, _connection);

            _connection.Open();
            _reader = sqlCommand.ExecuteReader();
            while (_reader.Read())
            {
                for (global::System.Int32 i = 0; i < _reader.FieldCount; i++)
                {
                    Content.Columns.Add(_reader.GetName(i), _reader[i].GetType());
                }
            }
            _connection.Close();
            return Content;
        }

    }
}
