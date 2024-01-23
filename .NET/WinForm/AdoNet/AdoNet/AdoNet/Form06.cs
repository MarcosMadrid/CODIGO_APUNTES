using AdoNet.Models;
using AdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet
{
    public partial class Form06 : Form
    {
        DepartamentosBBDD departamentosBBDD = new DepartamentosBBDD();
        List<Departamento> departamentos;

        public Form06()
        {
            InitializeComponent();
            LoadDepartamentos();
        }

        private void LoadDepartamentos()
        {
            listBox1.Items.Clear();
            departamentos = departamentosBBDD.GetDepartamentosBBDD();

            foreach (var departamento in departamentos)
            {
                listBox1.Items.Add(departamento);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            Departamento departamento = departamentosBBDD.GetDepartamentoBBDD(listBox1.SelectedItem as Departamento);
            numericUpDown1.Value = departamento.DEPT_NO;
            textBox1.Text = departamento.DNOMBRE;
            textBox2.Text = departamento.LOC;

            listBox1.SelectedItem = departamento;
            departamentos.Add(departamento);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            Departamento departamento = new Departamento();
            departamento.DEPT_NO = (int)numericUpDown1.Value;
            departamento.DNOMBRE = textBox1.Text;
            departamento.LOC = textBox2.Text;

            Departamento oldDept = listBox1.SelectedItem as Departamento;
            departamentosBBDD.UpdateDepartamentoBBDD(departamento, oldDept.DEPT_NO);

            listBox1.SelectedItem = departamento;
            LoadDepartamentos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            departamentosBBDD.UpdateDepartamentosBBDD(listBox1.Items.Cast<Departamento>().ToList());
            LoadDepartamentos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Departamento departamento = new Departamento();

            departamento.DEPT_NO = (int)numericUpDown2.Value;
            departamento.DNOMBRE = textBox3.Text;
            departamento.LOC = textBox4.Text;

            departamentosBBDD.InsertDepartamentoBBDD(departamento);
            LoadDepartamentos();
        }
    }
}
