using System.ComponentModel.DataAnnotations.Schema;

namespace ApiHospitalesNet.Models
{
    [Table("HOSPITAL")]
    public class Hospital
    {
        [Column("HOSPITAL_COD")]
        public int Id { get; set; }

        [Column("NOMBRE")]
        public string? Nombre { get; set; }

        [Column("DIRECCION")]
        public string? Direccion { get; set; }

        [Column("TELEFONO")]
        public string? Telefono { get; set; }

        [Column("NUM_CAMA")]
        public int? Camas { get; set; }
    }
}
