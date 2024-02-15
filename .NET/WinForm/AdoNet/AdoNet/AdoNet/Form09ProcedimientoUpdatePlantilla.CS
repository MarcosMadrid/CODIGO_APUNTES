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
    public partial class Form09ProcedimientoUpdatePlantilla : Form
    {
        private SqlConnection connection;
        private SqlDataReader reader;
        public Form09ProcedimientoUpdatePlantilla()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;Persist Security Info=True;User ID=SA;Password=MCSD2023;");


            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_HOSPITALES";
            connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["NOMBRE"].ToString());
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = comboBox1.SelectedItem.ToString();
            SqlParameter parameter = new SqlParameter("@NOMBREHOSPITAL", nombre);

            SqlCommand command = connection.CreateCommand();
            command.Parameters.Add(parameter);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_PLANTILLA_UPDATE";
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add("" +
                    reader["APELLIDO"].ToString() + "-" +
                    reader["SALARIO"].ToString() + ""
                    );
            }
            connection.Close();
        }
    }
}
