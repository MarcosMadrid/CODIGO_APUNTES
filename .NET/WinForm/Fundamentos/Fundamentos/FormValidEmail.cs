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
    public partial class FormValidEmail : Form
    {
        public FormValidEmail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string gmail = textBox1.Text;
            if (!gmail.Contains("@"))
            {
                valid = false;
            }
            var hola = gmail.Count(character => character == '@');

            if (gmail.Count(character => character.Equals("@")) > 1)
            {
                valid = false;
            }
            if (gmail.StartsWith("@"))
            {
                valid = false;
            }
            if (gmail.EndsWith("@"))
            {
                valid = false;
            }
            if (!gmail.Contains("."))
            {
                valid = false;
            }
            if (gmail.Count(character => character.Equals(".")) > 1)
            {
                valid = false;
            }
            if (gmail.Substring(gmail.IndexOf("@")).Length < 4)
            {
                valid = false;
            }
        }
    }
}
