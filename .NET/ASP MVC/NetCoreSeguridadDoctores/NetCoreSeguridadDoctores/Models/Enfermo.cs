using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreSeguridadDoctores.Models
{
    [Table("ENFERMO")]
    public class Enfermo
    {
        [Key]
        [Column("NSS")]
        public required string NSS { get; set; }

        [Column("INSCRIPCION")]
        public required string Inscripcion { get; set; }

        [Column("APELLIDO")]
        public required string Apellido { get; set; }

        [Column("DIRECCION")]
        public string? Direccion { get; set; }

        [Column("FECHA_NAC")]
        public DateTime FechaNac { get; set; }

        [Column("S")]
        public string? Sexo { get; set; }
    }
}
