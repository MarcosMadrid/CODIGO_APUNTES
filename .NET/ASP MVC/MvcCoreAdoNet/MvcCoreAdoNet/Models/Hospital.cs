using System.ComponentModel.DataAnnotations;

namespace MvcCoreAdoNet.Models
{
    public class Hospital
    {
        [Required]
        public int IdHospital { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? Nombre { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? Direccion { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(8, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string? Telefono { get; set; }

       
        public int Camas { get; set; }
    }
}
