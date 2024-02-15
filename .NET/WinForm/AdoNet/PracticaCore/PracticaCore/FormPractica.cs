using PracticaCore.Models;
using PracticaCore.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaCore
{
    public partial class FormPractica : Form
    {
        RepositoryLogistica repositoryLogistica = new RepositoryLogistica();
        List<Cliente> clientes;

        public FormPractica()
        {
            InitializeComponent();
            LoadClientes();
            RenderClientes_cmbclientes();
        }

        public void LoadClientes()
        {
            clientes = repositoryLogistica.GET_Clientes();
        }

        public List<Pedido> LoadPedidosCliente(string codigo_cliente)
        {
            List<Pedido> pedidosCliente = repositoryLogistica.GET_PedidosCliente(codigo_cliente);
            clientes[cmbclientes.SelectedIndex].Pedidos = pedidosCliente;
            return pedidosCliente;
        }

        public void RenderClientes_cmbclientes()
        {
            cmbclientes.Items.Clear();
            foreach (var cliente in clientes)
            {
                cmbclientes.Items.Add(cliente);
            }
        }

        public void RenderPedidos_lstpedidos(List<Pedido> pedidos)
        {
            lstpedidos.Items.Clear();
            foreach (var pedido in pedidos)
            {
                lstpedidos.Items.Add(pedido);
            }
        }

        private void cmbclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbclientes.SelectedIndex == -1)
            {
                return;
            }
            Cliente clienteSelected = cmbclientes.SelectedItem as Cliente;
            LoadPedidosCliente(clienteSelected.CodigoCliente);
            RenderPedidos_lstpedidos(clienteSelected.Pedidos);

            txtempresa.Text = clienteSelected.Empresa;
            txttelefono.Text = clienteSelected.Telefono.ToString();
            txtciudad.Text = clienteSelected.Ciudad;
            txtcargo.Text = clienteSelected.Cargo;
            txtcontacto.Text = clienteSelected.Contacto;
        }

        private void lstpedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstpedidos.SelectedIndex == -1)
            {
                return;
            }

            Pedido pedidoSelected = lstpedidos.SelectedItem as Pedido;
            txtimporte.Text = pedidoSelected.Importe.ToString();
            txtcodigopedido.Text = pedidoSelected.CodigoPedido;
            txtfechaentrega.Text = pedidoSelected.FechaEntrega;
            txtformaenvio.Text = pedidoSelected.FormaEnvio;
        }

        private void btnnuevopedido_Click(object sender, EventArgs e)
        {
            if (cmbclientes.SelectedIndex == -1)
            {
                return;
            }
            Cliente cliente = cmbclientes.SelectedItem as Cliente;
            Pedido pedido = new Pedido();

            pedido.CodigoCliente = (cmbclientes.SelectedItem as Cliente).CodigoCliente;
            pedido.Importe = int.Parse(txtimporte.Text);
            pedido.FechaEntrega = txtfechaentrega.Text;
            pedido.FormaEnvio = txtformaenvio.Text;
            pedido.CodigoPedido = txtcodigopedido.Text;

            repositoryLogistica.INSERT_Pedido(pedido);

            LoadClientes();
            LoadPedidosCliente(cliente.CodigoCliente);

            RenderPedidos_lstpedidos(LoadPedidosCliente(cliente.CodigoCliente));
        }

        private void btneliminarpedido_Click(object sender, EventArgs e)
        {

            if (lstpedidos.SelectedIndex == -1)
            {
                return;
            }
            Pedido pedido = lstpedidos.SelectedItem as Pedido;


            if (cmbclientes.SelectedIndex == -1)
            {
                return;
            }
            Cliente cliente = cmbclientes.SelectedItem as Cliente;


            this.repositoryLogistica.DELETE_Pedido(pedido.CodigoPedido);

            txtimporte.Clear();
            txtfechaentrega.Clear();
            txtformaenvio.Clear();
            txtcodigopedido.Clear();

            LoadClientes();
            LoadPedidosCliente(cliente.CodigoCliente);

            RenderPedidos_lstpedidos(LoadPedidosCliente(cliente.CodigoCliente));
        }
    }
}
