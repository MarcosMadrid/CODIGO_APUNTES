using System.ComponentModel;
using System.Data;

namespace MvcCoreLinqToSql.Models
{
    public class Empleado
    {
        [DefaultValue(0)]
        public int EMP_NO { get; set; }
        [DefaultValue("")]
        public string? OFICIO { get; set; }
        [DefaultValue("")]
        public string? APELLIDO { get; set; }
        [DefaultValue(0)]
        public int DIR { get; set; }
        [DefaultValue(typeof(DateTime), "1/1/0001 12:00:00 AM")]
        public DateTime FECHA_ALT { get; set; }

        public Empleado(DataRow empleado)
        {
            foreach (System.Reflection.PropertyInfo field in typeof(Empleado).GetProperties())
            {
                Object data = empleado[field.Name];
                if (data != null && data != DBNull.Value)
                {
                    field.SetValue(this, data);
                }
                else
                {
                    // Pone valor predeterminado
                    data = field.PropertyType.DeclaringType;
                    field.SetValue(this, data);
                }
            }
        }
    }

}
