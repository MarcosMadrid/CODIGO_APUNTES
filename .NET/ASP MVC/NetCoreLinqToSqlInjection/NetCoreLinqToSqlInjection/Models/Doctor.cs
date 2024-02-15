using System.ComponentModel.DataAnnotations;

namespace NetCoreLinqToSqlInjection.Models
{
    public class Doctor
    {
        public string? HOSPITAL_COD { get; set; }

        [Required]
        public string? DOCTOR_NO { get; set; }

        public string? APELLIDO { get; set; }

        public string? ESPECIALIDAD { get; set; }

        [DataType(DataType.Currency)]
        public int SALARIO { get; set; }

    }
}
