﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPeliculas.Models
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }

        public string? Genero { get; set; }

        public string? Titulo { get; set; }

        public string? Argumento { get; set; }

        public string? Actores { get; set; }

        public int Precio { get; set; }

        public string? Foto { get; set; }

        public string? Youtube { get; set; }
    }
}
