using System.ComponentModel.DataAnnotations;

namespace WebApplicationPersonasMvc.Models
{
    public class Personaje
    {
        [Required]
        public int IDPERSONAJE { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Imagen { get; set; }
    }
}
