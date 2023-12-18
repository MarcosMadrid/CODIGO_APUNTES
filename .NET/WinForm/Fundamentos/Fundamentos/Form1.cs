using static System.Windows.Forms.AxHost;
using System.Drawing;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Fundamentos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnNombre_Click(object sender, EventArgs e)
        {
            this.LabelNombre.Location = new Point(60, 39);
            this.LabelNombre.ForeColor =  Color.FromArgb(1, 100, 200, 23);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
