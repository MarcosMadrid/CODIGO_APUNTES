using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaMvcCore2Iniciales.Models
{
    [Table("GENEROS")]
    public class Genero
    {
        [Key]
        [Required]
        [Column("IdGenero")]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }
    }
}
