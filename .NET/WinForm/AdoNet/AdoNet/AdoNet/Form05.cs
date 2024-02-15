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
    public partial class Form05 : Form
    {
        string connectorString = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;Persist Security Info=True;User ID=SA;Password=MCSD2023;";
        SqlConnection connection;
        public Form05()
        {
            InitializeComponent();
            connection = new SqlConnection(connectorString);
            LoadDepartamentos();
        }
        public void LoadDepartamentos()
        {
            listBox1.Items.Clear();
            string sql = "SELECT DEPT.DNOMBRE FROM DEPT";
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["DNOMBRE"].ToString());
            }
            dr.Close();
            connection.Close();
        }

        public void LoadEmpDept()
        {
            if (this.listBox1.SelectedIndex == -1)
            {
                return;
            }
            listBox2.Items.Clear();
            string sql = "SELECT EMP.APELLIDO FROM EMP WHERE EMP.DEPT_NO = (SELECT DEPT.DEPT_NO FROM DEPT WHERE DNOMBRE = @DNOMBRE)";
            SqlParameter cmd = new SqlParameter("DNOMBRE", listBox1.Items[this.listBox1.SelectedIndex].ToString());
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.Add(cmd);
            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                listBox2.Items.Add(sqlDataReader["APELLIDO"].ToString());
            }
            connection.Close();
        }

        public void LoadEmpData()
        {
            if (this.listBox2.SelectedIndex == -1)
            {
                return;
            }           
            string sql = "SELECT * FROM EMP WHERE EMP.APELLIDO = @APELLIDO";
            SqlParameter cmd = new SqlParameter("APELLIDO", listBox2.Items[this.listBox2.SelectedIndex].ToString());
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.Add(cmd);
            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                numericUpDown1.Value = decimal.Parse(sqlDataReader["SALARIO"].ToString());
                numericUpDown2.Value = decimal.Parse(sqlDataReader["COMISION"].ToString());
                textBox1.Text = sqlDataReader["OFICIO"].ToString();
            }
            connection.Close();
        }

        public void UpdateEmpData()
        {
            string sql = "UPDATE EMP SET SALARIO = @SALARIO , COMISION = @COMISION , OFICIO = @OFICIO WHERE APELLIDO = @APELLIDO";
            SqlParameter apellido = new SqlParameter("APELLIDO", listBox2.Items[this.listBox2.SelectedIndex].ToString());
            SqlParameter salario = new SqlParameter("SALARIO", numericUpDown1.Value);
            SqlParameter comision = new SqlParameter("COMISION", numericUpDown2.Value);
            SqlParameter oficio = new SqlParameter("OFICIO", textBox1.Text);

            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.Add(apellido);
            sqlCommand.Parameters.Add(salario);
            sqlCommand.Parameters.Add(comision);
            sqlCommand.Parameters.Add(oficio);

            connection.Open();
            sqlCommand.ExecuteReader();
            connection.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmpDept();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateEmpData();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmpData();
        }
    }
}
