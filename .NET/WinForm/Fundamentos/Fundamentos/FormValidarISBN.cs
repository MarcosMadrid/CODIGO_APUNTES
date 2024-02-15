using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fundamentos
{
    public partial class FormValidarISBN : Form
    {
        public FormValidarISBN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isbn = textBox1.Text;
            double resultado = isbn.Select((value, i) => Char.GetNumericValue(value) * (i + 1)).Sum();

            if (resultado % 11 == 0)
            {
                MessageBox.Show("ISBN CORRECTO", "IDSB OK", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }
    }
}
