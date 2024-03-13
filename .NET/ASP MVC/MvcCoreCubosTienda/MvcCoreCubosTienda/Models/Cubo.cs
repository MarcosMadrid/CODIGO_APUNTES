using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreCubosTienda.Models
{
    [Table("CUBOS")]
    public class Cubo
    {
        [Key]
        [Required]
        [Column("id_cubo")]
        public int Id { get; set; }

        [Column("nombre")]
        public string? Name { get; set; }

        [Column("modelo")]
        public string? Modelo { get; set; }

        [Column("imagen")]
        public string? Imagen { get; set; }

        [Required]
        [Column("precio")]
        public int Precio { get; set; }
    }
}
