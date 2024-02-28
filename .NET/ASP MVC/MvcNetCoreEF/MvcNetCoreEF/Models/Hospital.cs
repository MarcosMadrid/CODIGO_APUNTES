using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcNetCoreEF.Models
{
    [Table("HOSPITAL")]
    public class Hospital
    {
        [Key]
        [Required]
        [Column("HOSPITAL_COD")]
        public int IdHospital { get; set; }

        [Column("NOMBRE")]
        public string? Nombre { get; set; }

        [Column("TELEFONO")]
        public string? Telefono { get; set; }

        [Required]
        [Column("NUM_CAMA")]
        public string? Camas { get; set; }

        [Column("DIRECCION")]
        public string? Direccion { get; set; }

    }
}
