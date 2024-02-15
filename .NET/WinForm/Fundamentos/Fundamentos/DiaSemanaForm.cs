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
    public partial class DiaSemanaForm : Form
    {
        public DiaSemanaForm()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var dia_semana = dateTimePicker1.Value.DayOfWeek;
            label1.Text = dia_semana.ToString();
        }
    }
}
