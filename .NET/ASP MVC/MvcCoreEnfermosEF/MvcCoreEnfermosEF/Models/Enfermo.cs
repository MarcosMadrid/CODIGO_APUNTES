using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreEnfermosEF.Models
{
    [Table("ENFERMO")]
    public class Enfermo
    {
        [Key]
        [Required]
        [Column("INSCRIPCION")]
        public string Inscripcion { get; set; }

        [Column("APELLIDO")]
        public string Apellido { get; set; }

        [Column("DIRECCION")]
        public string Direccion { get; set; }

        [Column("FECHA_NAC")]
        public DateTime Fecha_Nac { get; set; }

        [Column("S")]
        public string GeneroBioogico { get; set; }

        [Column("NSS")]
        public string NSS { get; set; }
    }
}
