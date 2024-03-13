using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreEmpleados.Models
{
    [Table("EMP")]
    public class Empleado
    {
        [Key]
        [Column("EMP_NO")]
        public int IdEmpleado { get; set; }

        [Column("APELLIDO")]
        public string Apellidos { get; set; }

        [Column("OFICIO")]
        public string Oficio { get; set; }

        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}
