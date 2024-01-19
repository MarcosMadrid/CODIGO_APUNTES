using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Fundamentos
{
    public partial class Form27ColeccionBinaryMascotas : Form
    {
        XmlSerializer serializer = new XmlSerializer(typeof(CollectionMascotas));
        CollectionMascotas mascotasList = new CollectionMascotas();
        BinaryFormatter formatter = new BinaryFormatter();

        public Form27ColeccionBinaryMascotas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mascota mascota = new Mascota(textBox1.Text, textBox2.Text);
            listBox1.Items.Add(mascota);
            mascotasList.Add(mascota);

            textBox1.Clear();
            textBox2.Clear();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                {
                    this.serializer.Serialize(writer, mascotasList);
                    await writer.FlushAsync();
                    writer.Close();
                }
                this.listBox1.Items.Clear();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                // Serialize object to XML
                using (var xmlStream = new MemoryStream())
                {
                    XmlWriterSettings settings = new XmlWriterSettings
                    {
                        Encoding = Encoding.ASCII,
                        Indent = true,
                    };

                    XmlWriter xmlWriter = XmlWriter.Create(xmlStream, settings);
                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    this.serializer.Serialize(xmlWriter, mascotasList, namespaces);

                    // Convert XML content to Base64 string
                    string base64String = Convert.ToBase64String(xmlStream.ToArray());

                    // Write the Base64 string to the file
                    File.WriteAllText(saveFile.FileName, base64String);
                }


                string base64Content = File.ReadAllText(saveFile.FileName);
                byte[] binaryData = Convert.FromBase64String(base64Content);

            }
        }
    }
}
