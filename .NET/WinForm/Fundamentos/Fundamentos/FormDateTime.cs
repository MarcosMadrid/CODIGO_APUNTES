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
    public partial class FormDateTime : Form
    {
        public FormDateTime()
        {
            InitializeComponent();
        }

        private void FormDateTime_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string operation = "";

            operation = comboBox1.Text;


            if (operation == "Dia")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(int.Parse(textBox2.Text));
            }
            if (operation == "Mes")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(int.Parse(textBox2.Text));
            }
            if (operation == "Año")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddYears(int.Parse(textBox2.Text));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            }
            else
            {
                dateTimePicker1.Format = DateTimePickerFormat.Long;
            }
        }
    }
}
