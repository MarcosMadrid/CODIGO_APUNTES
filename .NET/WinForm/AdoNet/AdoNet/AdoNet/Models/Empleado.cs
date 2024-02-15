using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Models
{
    public class Empleado
    {
        public string APELLIDO { get; set; }
        public string OFICIO { get; set; }
        public int SALARIO { get; set; }
        public int COMISION { get; set; }

        public override string ToString()
        {
            return this.APELLIDO;
        }
    }
}
