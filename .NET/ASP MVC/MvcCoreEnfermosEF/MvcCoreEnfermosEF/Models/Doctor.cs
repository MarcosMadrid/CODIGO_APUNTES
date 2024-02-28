using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreEnfermosEF.Models
{
    [Table("DOCTOR")]
    public class Doctor
    {
        [Required]
        [DataType("integer")]
        [Column("HOSPITAL_COD")]
        public int HOSPITAL_COD { get; set; }

        [Required]
        [Key]
        [DataType(DataType.Text)]
        [Column("DOCTOR_NO")]
        public required string DOCTOR_NO { get; set; }

        [DataType(DataType.Text)]
        [Column("APELLIDO")]
        public string? APELLIDO { get; set; }

        [DataType(DataType.Text)]
        [Column("ESPECIALIDAD")]
        public string? ESPECIALIDAD { get; set; }

        [DataType(DataType.Currency)]
        [Column("SALARIO")]
        public int SALARIO { get; set; }
    }
}
