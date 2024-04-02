using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaMvcCore2Iniciales.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("IdUsuario")]
        public int Id { get; set; }

        [Required]
        [Column("Nombre")]
        [DataType(DataType.Text)]
        public string? Nombre { get; set; }

        [Required]
        [Column("Apellidos")]
        [DataType(DataType.Text)]
        public string? Apellidos { get; set; }

        [Required]
        [Column("Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [Column("Pass")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Column("Foto")]
        public string? Foto { get; set; }
    }
}
