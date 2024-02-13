using MvcCoreLinqToSql.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreLinqToSql.Repositories
{
    public class RepositoryEmp
    {
        private DataTable _Table = new DataTable();

        public RepositoryEmp()
        {
            string connection = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;User ID=SA;Password=MCSD2023;";
            string sql = "SELECT * FROM EMP";
            SqlDataAdapter adEmp = new SqlDataAdapter(sql, connection);
            adEmp.Fill(_Table);
        }

        public List<Empleado> GetEmpleados()
        {
            List<Empleado> empleados = _Table.AsEnumerable()
                .Select(empleadoRow => new Empleado(empleadoRow))
                .ToList();

            return empleados;
        }

        public List<string?> GetOficiosEmpleados()
        {
            List<string?> oficios = _Table.AsEnumerable()
                .Select(empleadoRow => empleadoRow.Field<string?>("OFICIO"))
                .Distinct()
                .ToList();

            return oficios;
        }

        public List<Empleado>? GetEmpleadosByOficio(string oficio)
        {
            if (oficio == null)
            {
                return null;
            }
            List<Empleado> empleados = new List<Empleado>();

            empleados = _Table.AsEnumerable()
                .Select(empleadoRow => new Empleado(empleadoRow))
                .Where(empleadoRow => empleadoRow.OFICIO.Equals(oficio))
                .ToList();

            if (empleados.Count() == 0)
            {
                return null;
            }

            return empleados;
        }
    }
}
