using System;
using System.Collections;
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
    public partial class Form04 : Form
    {
        SqlConnection connection;
        string connectorString = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;Persist Security Info=True;User ID=SA;Password=MCSD2023;";

        public Form04()
        {
            InitializeComponent();
            this.connection = new SqlConnection(this.connectorString);
            LoadSalaNombres();
        }
        public void LoadSalaNombres()
        {
            listBox1.Items.Clear();
            string query = "SELECT SALA.NOMBRE FROM SALA GROUP BY SALA.NOMBRE";
            SqlCommand command = this.connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                this.listBox1.Items.Add(reader["NOMBRE"].ToString());
            }
            reader.Close();
            connection.Close();
        }
        public void ModifyNombreSala()
        {
            string sala_nombre = listBox1.Items[this.listBox1.SelectedIndex].ToString();
            string nombretxt = textBox1.Text;
            string sql = "UPDATE SALA SET NOMBRE=@nombretxt WHERE SALA.NOMBRE=@sala_nombre";
            SqlCommand command = this.connection.CreateCommand();

            SqlParameter salaNombre = new SqlParameter();
            salaNombre.ParameterName = "@sala_nombre";
            salaNombre.DbType = DbType.String;
            salaNombre.Value = sala_nombre;

            SqlParameter nombre = new SqlParameter();
            nombre.ParameterName = "@nombretxt";
            nombre.DbType = DbType.String;
            nombre.Value = nombretxt;

            command.Parameters.Add(salaNombre);
            command.Parameters.Add(nombre);

            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            LoadSalaNombres();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModifyNombreSala();
        }
    }
}
