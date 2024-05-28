﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAWS.Models
{
    [Table("DEPT")]
    public class Departamento
    {
        [Key]
        [Required]
        [Column("DEPT_NO")]
        public int Id { get; set; }

        [Column("DNOMBRE")]
        public string? Nombre { get; set; }

        [Column("LOC")]
        public string? Localidad { get; set; }
    }
}