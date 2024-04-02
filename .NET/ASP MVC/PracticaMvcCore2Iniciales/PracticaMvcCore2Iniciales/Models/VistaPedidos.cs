﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaMvcCore2Iniciales.Models
{
    [Table("VISTAPEDIDOS")]
    public class VistaPedidos
    {
        [Key]
        [Column("IDVISTAPEDIDOS")]
        public int VistaPedido { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("Nombre")]
        public string? Nombre { get; set; }

        [Column("Apellidos")]
        public string? Apellidos { get; set; }

        [Column("Titulo")]
        public string? Titulo { get; set; }

        [Column("Precio")]
        public int Precio { get; set; }

        [Column("Portada")]
        public string? Portada { get; set; }

        [Column("FECHA")]
        public DateTime FECHA { get; set; }

        [Column("PRECIOFINAL")]
        public int PRECIOFINAL { get; set; }
    }
}
