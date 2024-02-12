using System.ComponentModel.DataAnnotations;

namespace MvcCoreCrudDepartamentos.Models
{
    public class Departamento
    {
        public int DEPT_NO { get; set; }
        [Required]
        public string DNOMBRE { get; set; } = string.Empty;
        [Required]
        public string LOC { get; set; } = string.Empty;
    }
}
