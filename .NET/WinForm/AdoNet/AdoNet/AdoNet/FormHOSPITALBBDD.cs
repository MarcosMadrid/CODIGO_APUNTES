using AdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet
{
    public partial class FormHOSPITALBBDD : Form
    {
        HOSPITALBBDDConnector connector = new HOSPITALBBDDConnector();

        public FormHOSPITALBBDD()
        {
            InitializeComponent();
            LoadTables();
        }

        public void LoadTables()
        {
            List<string> list_tables = connector.GetTablesNames();
            foreach (var name in list_tables)
            {
                listBox1.Items.Add(name);
            }
        }

        public void LoadTableContent()
        {
            connector.GetTableContent(listBox1.SelectedItem as string);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTableContent();
        }
    }
}
