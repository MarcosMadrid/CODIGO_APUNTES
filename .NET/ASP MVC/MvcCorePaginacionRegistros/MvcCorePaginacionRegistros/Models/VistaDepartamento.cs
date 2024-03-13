﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCorePaginacionRegistros.Models
{
    [Table("V_DEPARTAMENTO_INDIVIDUAL")]
    public class VistaDepartamento
    {
        [Key]
        [Required]
        [Column("DEPT_NO")]
        public int Id { get; set; }

        [Column("POSICION")]
        public int Posicion { get; set; }

        [Column("DNOMBRE")]
        public string Nombre { get; set; }

        [Column("LOC")]
        public string Localidad { get; set; }
    }
}
