using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEntityFrameWorkComics.Models
{
    [Table("COMICS")]
    public class Comic
    {
        [Key]
        [Required]
        [Column("IDCOMIC")]
        public int Id { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }
    }
}
