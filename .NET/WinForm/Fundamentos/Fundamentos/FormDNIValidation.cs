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
    public partial class FormDNIValidation : Form
    {
        public FormDNIValidation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numero_DNI = textBox1.Text;
            string[] dni = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            string letra = dni[Convert.ToInt32(numero_DNI) - (Convert.ToInt32(numero_DNI) / 23) * 23];
            MessageBox.Show(letra);
        }
    }
}
