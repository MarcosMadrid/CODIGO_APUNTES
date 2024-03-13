using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreCubosTienda.Models
{
    [Table("COMPRA")]
    public class Compra
    {
        [Key]
        [Required]
        [Column("id_compra")]
        public int Id { get; set; }

        [Column("nombre_cubo")]
        public string? Name { get; set; }

        [Column("precio")]
        public int Precio { get; set; }

        [Column("fechapedido")]
        public DateTime FechaPedido { get; set; }
    }
}
