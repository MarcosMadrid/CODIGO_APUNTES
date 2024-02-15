using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCore.Models
{
    public class Pedido
    {
        public string? CodigoPedido { get; set; }
        public string? CodigoCliente { get; set; }
        public string? FechaEntrega { get; set; }
        public string? FormaEnvio { get; set; }
        public int Importe { get; set; }

        public override string ToString()
        {
            DateTime fecha_entrega = DateTime.Parse(FechaEntrega);
            string mes_string = fecha_entrega.ToString("MMMM").First().ToString().ToUpper() + String.Join("", fecha_entrega.ToString("MMMM").Skip(1));
            return mes_string + "-" + fecha_entrega.Day + "-" + fecha_entrega.Year;
        }
    }
}
