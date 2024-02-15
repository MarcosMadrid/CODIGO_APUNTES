using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data;

namespace AdoNet
{
    public partial class Form01PrimerAdo : Form
    {
        string connectionString = string.Empty;
        SqlConnection connection;

        public Form01PrimerAdo()
        {
            InitializeComponent();
            this.connectionString = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;Persist Security Info=True;User ID=SA;Password=MCSD2023;";
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                this.connection = new SqlConnection(connectionString);
                this.connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_disconnet_Click(object sender, EventArgs e)
        {
            try
            {
                this.connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
                string query = "SELECT * FROM EMP";            
            try
            {
                SqlCommand command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();
                lst_columnas.Items.Add(reader.GetName(0));
                lst_datos.Items.Add(reader.GetDataTypeName(0));
                
                while (reader.Read())
                {
                    lst_apellidos.Items.Add(reader["APELLIDO"].ToString());
                }               
                reader.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
