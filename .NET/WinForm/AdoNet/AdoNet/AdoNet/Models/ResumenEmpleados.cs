using System;
using System.Collections.Generic;

namespace AdoNet.Models
{
    public class ResumenEmpleados
    {
        public List<String> Apellidos { get; set; }
        public int SumaSalarial { get; set; }
        public int MediaSalarial { get; set; }
        public int TotalPersonas { get; set; }

        public ResumenEmpleados()
        {

        }
    }
}
