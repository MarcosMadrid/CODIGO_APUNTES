namespace PracticaCore.Models
{
    public class Cliente
    {
        public string? CodigoCliente { get; set; }
        public string? Empresa { get; set; }
        public string? Contacto { get; set; }
        public string? Cargo { get; set; }
        public string? Ciudad { get; set; }
        public int Telefono { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Cliente()
        {
            Pedidos = new List<Pedido>();
        }

        public override string ToString()
        {
            return Empresa;
        }
    }
}
