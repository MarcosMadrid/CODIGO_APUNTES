using AdoNet.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet
{
    public partial class Form10MensajeServer : Form
    {
        SqlConnection connection;
        SqlDataReader reader;
        public Form10MensajeServer()
        {
            InitializeComponent();
            connection = new SqlConnection(HelpersConfiguration.GetConnectionString());
            LoadDepartamentos();
        }

        public void LoadDepartamentos()
        {
            listBox1.Items.Clear();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SP_DEPARTAMENTOS";
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add("" +
                    "" + reader["DEPT_NO"].ToString() + "-" +
                    "" + reader["DNOMBRE"].ToString() + "-" +
                    "" + reader["LOC"].ToString());
            }
            connection.Close();
        }

        public void InsertDepartamento(string nombre, int dept_no, string loc)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT_DEPT";
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter = new SqlParameter("@DNOMBRE", nombre);
            command.Parameters.Add(parameter);
            parameter = new SqlParameter("@DEPT_NO", dept_no);
            command.Parameters.Add(parameter);
            parameter = new SqlParameter("@LOC", loc);
            command.Parameters.Add(parameter);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
            LoadDepartamentos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertDepartamento(textBox2.Text, int.Parse(textBox1.Text), textBox3.Text);
        }
    }
}
