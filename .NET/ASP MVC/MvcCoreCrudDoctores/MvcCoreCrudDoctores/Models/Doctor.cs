using System.ComponentModel.DataAnnotations;

namespace MvcCoreCrudDoctores.Models
{
    public class Doctor
    {
        [Required]
        public string HOSPITAL_COD { get; set; } = string.Empty;
        [Required]
        public string DOCTOR_NO { get; set; } = string.Empty;
        [Required]
        public string APELLIDO { get; set; } = string.Empty;
        [Required]
        public string ESPECIALIDAD { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public int SALARIO { get; set; }
    }
}
