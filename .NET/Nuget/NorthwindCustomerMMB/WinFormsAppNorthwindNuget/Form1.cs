using NorthwindCustomerMMB.Models;
using NorthwindCustomerMMB.Services;

namespace WinFormsAppNorthwindNuget
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ServiceNorthwind service = new ServiceNorthwind();
            ListCustomers listCustomers = await service.GetCustomersAsync();
            foreach (var item in listCustomers.Customers)
            {
                this.listBox1.Items.Add(item.Name);
            }
        }
    }
}
