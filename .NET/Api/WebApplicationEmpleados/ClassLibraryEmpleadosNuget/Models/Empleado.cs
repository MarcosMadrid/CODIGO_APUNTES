﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationEmpleados.Models
{
    [Table("EMP")]
    public class Empleado
    {
        [Required]
        [Column("EMP_NO")]
        public int Id { get; set; }

        [Column("APELLIDO")]
        public string? Apellido { get; set; }

        [Column("OFICIO")]
        public string? Oficio { get; set; }

        [Column("SALARIO")]
        public int Salario { get; set; }

        [Column("DEPT_NO")]
        public int IdDepartamento { get; set; }
    }
}