using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.Models
{
    public class Departamento
    {
        public int DEPT_NO { get; set; } = 0;
        public string DNOMBRE { get; set; } = string.Empty;
        public string LOC { get; set; } = string.Empty;

        public Departamento() { }

        public override string ToString()
        {
            return this.DNOMBRE;
        }
    }
}
