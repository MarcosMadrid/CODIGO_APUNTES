using System.Windows;

namespace Fundamentos
{
    public partial class NumerosRandomList : Form
    {
        public NumerosRandomList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Byte[] ArrayNums = new byte[10];
            foreach (byte b in ArrayNums)
            {
                new Random().NextBytes(ArrayNums);
                listBox1.Items.Add(b);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
