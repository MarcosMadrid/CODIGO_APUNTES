using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleAppChollometro.Models
{
    [Table("CHOLLOS")]

    public class Chollo
    {
        [Column("IDCHOLLO")]
        public int Id { get; set; }

        [Column("TITULO")]
        public string? Titulo { get; set; }

        [Column("LINK")]
        public string? Link { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("FECHA")]
        public DateTime? Fecha { get; set; }
    }
}
