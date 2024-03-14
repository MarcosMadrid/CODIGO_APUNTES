using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreSeguridadDoctores.Models
{
    [Table("DOCTOR")]
    public class Doctor
    {
        [Key]
        [Column("DOCTOR_NO")]
        public required string Id { get; set; }

        [Column("HOSPITAL_COD")]
        public int HospitalId { get; set; }

        [Column("APELLIDO")]
        public required string Apellido { get; set; }

        [Column("ESPECIALIDAD")]
        public string? Especialidad { get; set; }

        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}
