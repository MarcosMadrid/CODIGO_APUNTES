using System.ComponentModel.DataAnnotations;

namespace MvcCoreAdoNet.Models
{
    public class Doctor
    {
        [Required]
        public string HOSPITAL_COD { get; set; }

        [Required]
        public string DOCTOR_NO { get; set; }

        [Required]
        public string APELLIDO { get; set; }

        [Required]
        public string ESPECIALIDAD { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int SALARIO { get; set; }

    }
}
