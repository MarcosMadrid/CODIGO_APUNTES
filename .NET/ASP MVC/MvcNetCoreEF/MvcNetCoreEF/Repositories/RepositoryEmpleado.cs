using MvcNetCoreEF.Data;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Repositories
{
    public class RepositoryEmpleado
    {
        readonly private HospitalContext context;

        public RepositoryEmpleado(HospitalContext context)
        {
            this.context = context;
        }

        public List<string>? GetOficios()
        {
            List<string?>? oficios = context.Empleados
                .Select(empleadoRow => empleadoRow.Oficio)
                .Distinct()
                .ToList();

            if (oficios == null)
            {
                return null;
            }

            return oficios;
        }

        public List<Empleado>? GetEmpleadosOficio(string oficio)
        {
            List<Empleado>? empleados = context.Empleados
                .Where(empleadoRow => empleadoRow.Oficio.Equals(oficio))
                .ToList();

            if (empleados == null)
            {
                return null;
            }

            return empleados;
        }

        public List<Empleado>? GetEmpleados()
        {
            List<Empleado>? empleados = context.Empleados.ToList();
               

            if (empleados == null)
            {
                return null;
            }

            return empleados;
        }

        public List<Empleado>? IncerementarSalarioOficios(int incremento, string oficio)
        {
            List<Empleado>? empleados = GetEmpleadosOficio(oficio);

            if (empleados == null)
            {
                return null;
            }

            foreach (Empleado item in empleados)
            {
                item.Salario += incremento;
            }
            context.SaveChanges();

            return empleados;
        }

        public double? GetMediaSalario(string oficio)
        {
            List<Empleado>? empleados = GetEmpleadosOficio(oficio);
            if (empleados == null)
            {
                return null;
            }
            double media = empleados.Average(empleado => empleado.Salario);
            return media;
        }
    }
}
