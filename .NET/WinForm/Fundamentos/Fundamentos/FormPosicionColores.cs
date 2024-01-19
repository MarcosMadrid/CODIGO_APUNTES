using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fundamentos
{
    public partial class FormPosicionColores : Form
    {
        public FormPosicionColores()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(int.Parse(this.textBox3.Text), int.Parse(this.textBox4.Text), int.Parse(this.textBox5.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Location = new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
        }

        private void FormPosicionColores_Load(object sender, EventArgs e)
        {

        }
    }
}
