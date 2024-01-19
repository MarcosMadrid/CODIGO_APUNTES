using static System.Windows.Forms.AxHost;
using System.Drawing;
using System.Xml.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;

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
            this.LabelNombre.ForeColor = Color.FromArgb(1, 100, 200, 23);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MetroForm ventana = new Form01SumarNumeros();
            ventana.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ventana = new FormPosicionColores();
            ventana.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ventana = new DiaSemanaForm();
            ventana.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ventana = new FormDateTime();
            ventana.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form ventana = new FormValidEmail();
            ventana.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form ventana = new FormValidarISBN();
            ventana.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form ventana = new FormDNIValidation();
            ventana.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form ventana = new NumerosRandomList();
            ventana.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form ventana = new Form27ColeccionBinaryMascotas();
            ventana.ShowDialog();
        }
    }
}
