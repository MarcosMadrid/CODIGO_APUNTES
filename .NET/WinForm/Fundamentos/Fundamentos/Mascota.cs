using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentos
{
    [Serializable]
    public class Mascota
    {
        public string Nombre { get; set; }
        public string Raza { get; set; }

        public Mascota(string nombre, string raza)
        {
            Nombre = nombre;
            Raza = raza;
        }

        public Mascota() { }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
