using AdoNet.Models;
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
    public partial class FormPractica2 : Form
    {
        private Repositories.RepositoryEmpBBDD empBBDD = new Repositories.RepositoryEmpBBDD();
        List<Empleado> empleados = new List<Empleado>();
        public FormPractica2()
        {
            InitializeComponent();
            LoadEmpleados();
        }

        public void LoadEmpleados()
        {
            empleados.Clear();
            empleados = empBBDD.GetEmpleados();
            foreach (var empleado in empleados)
            {
                if (!listBox1.Items.Contains(empleado.OFICIO))
                {
                    listBox1.Items.Add(empleado.OFICIO);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            foreach (var empleado in empleados)
            {
                if (empleado.OFICIO.Equals(listBox1.SelectedItem as string))
                {
                    listBox2.Items.Add(empleado);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            empBBDD.UpdateSalarioEmps(listBox1.SelectedItem as string, (int)numericUpDown1.Value);
        }
    }
}
