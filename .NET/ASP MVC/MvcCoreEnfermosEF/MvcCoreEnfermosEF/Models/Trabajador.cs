using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreEnfermosEF.Models
{
    [Table("V_TRABAJADORES")]
    public class Trabajador
    {
        [Key]
        [Required]
        [Column("IDTRABAJADOR")]
        public required int TrabajadorId { get; set; }

        [Column("APELLIDO")]
        public string? Apellido { get; set; }

        [Column("OFICIO")]
        public string? Oficio { get; set; }

        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}
