using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDockersComics.Models
{
    [Table("COMICS")]
    public class Comic
    {
        [Key]
        [Column("IDCOMIC")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public string? Name { get; set; }

        [Column("IMAGEN")]
        public string? Imagen { get; set; }
    }
}
