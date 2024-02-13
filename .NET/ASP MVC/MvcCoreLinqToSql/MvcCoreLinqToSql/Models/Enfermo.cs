using System;
using System.ComponentModel;

namespace MvcCoreLinqToSql.Models
{
    public class Enfermo
    {
        [DefaultValue(null)]
        public string? INSCRIPCION { get; set; }
        [DefaultValue(null)]
        public string? APELLIDO { get; set; }
        [DefaultValue(null)]
        public string? DIRECCION { get; set; }
        [DefaultValue(null)]
        public DateTime? FECHA_NAC { get; set; }
        [DefaultValue(null)]
        public string? S { get; set; }
        [DefaultValue(null)]
        public string? NSS { get; set; }

        public Enfermo()
        {
        }
    }
}
