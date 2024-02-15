using PracticaCore.Models;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Diagnostics.Metrics;

namespace PracticaCore.Repositories
{
    public class RepositoryLogistica
    {
        SqlConnection sqlConnection;
        SqlDataReader sqlReader;

        public RepositoryLogistica()
        {
            sqlConnection = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=NETCOREEXAM;Persist Security Info=True;User ID=SA;Password=MCSD2023;");
        }

        public List<Cliente> GET_Clientes()
        {
            var list = new List<Cliente>();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "SP_CLIENTES";
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                Cliente cliente = new Cliente();

                cliente.CodigoCliente = sqlReader["CodigoCliente"].ToString();
                cliente.Empresa = sqlReader["Empresa"].ToString();
                cliente.Contacto = sqlReader["Contacto"].ToString();
                cliente.Cargo = sqlReader["Cargo"].ToString();
                cliente.Ciudad = sqlReader["Ciudad"].ToString();
                cliente.Telefono = int.Parse(sqlReader["Telefono"].ToString());

                list.Add(cliente);
            }
            sqlConnection.Close();

            return list;
        }


        public List<Pedido> GET_PedidosCliente(string codigo_empresa)
        {
            var list = new List<Pedido>();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "SP_CLIENTES_PEDIDOS";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter codigoEmpresa = new SqlParameter("@IDEMPRESA", codigo_empresa);
            cmd.Parameters.Add(codigoEmpresa);

            sqlConnection.Open();
            sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                Pedido pedido = new Pedido();

                pedido.CodigoPedido = sqlReader["CodigoPedido"].ToString();
                pedido.CodigoCliente = sqlReader["CodigoCliente"].ToString();
                pedido.FechaEntrega = sqlReader["FechaEntrega"].ToString();
                pedido.FormaEnvio = sqlReader["FormaEnvio"].ToString();
                pedido.Importe = int.Parse(sqlReader["Importe"].ToString());

                list.Add(pedido);
            }
            sqlConnection.Close();

            return list;
        }

        public void INSERT_Pedido(Pedido pedido)
        {
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO pedidos VALUES(@CodigoPedido,@CodigoCliente,@FechaEntrega,@FormaEnvio,@Importe)";

            SqlParameter codigoPedido = new SqlParameter("@CodigoPedido", pedido.CodigoPedido);
            SqlParameter codigoCliente = new SqlParameter("@CodigoCliente", pedido.CodigoCliente);
            SqlParameter fechaEntrega = new SqlParameter("@FechaEntrega", pedido.FechaEntrega);
            SqlParameter formaEnvio = new SqlParameter("@FormaEnvio", pedido.FormaEnvio);
            SqlParameter importe = new SqlParameter("@Importe", pedido.Importe);

            cmd.Parameters.Add(codigoPedido);
            cmd.Parameters.Add(codigoCliente);
            cmd.Parameters.Add(fechaEntrega);
            cmd.Parameters.Add(formaEnvio);
            cmd.Parameters.Add(importe);

            sqlConnection.Open();
            cmd.ExecuteReader();
            sqlConnection.Close();
        }

        public void DELETE_Pedido(string codigo_pedido)
        {
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "DELETE FROM pedidos WHERE CodigoPedido = @CodigoPedido";

            SqlParameter codigoPedido = new SqlParameter("@CodigoPedido", codigo_pedido);
            cmd.Parameters.Add(codigoPedido);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        // PROCEDURE SP_CLIENTES
        //ALTER PROCEDURE[dbo].[SP_CLIENTES]
        //AS
        //BEGIN
        //    SELECT* FROM clientes
        //END

        // PROCEDURE SP_CLIENTES_PEDIDOS
        //ALTER PROCEDURE[dbo].[SP_CLIENTES_PEDIDOS]
        //(@IDEMPRESA NVARCHAR(50))
        //AS
        //BEGIN
        //    SELECT* FROM pedidos WHERE pedidos.CodigoCliente = @IDEMPRESA
        //END
    }
}
