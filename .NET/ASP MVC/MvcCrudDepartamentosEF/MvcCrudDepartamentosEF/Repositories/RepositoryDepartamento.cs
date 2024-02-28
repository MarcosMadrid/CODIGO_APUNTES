using MvcCrudDepartamentosEF.Data;
using MvcCrudDepartamentosEF.Models;

namespace MvcCrudDepartamentosEF.Repositories
{
    public class RepositoryDepartamento
    {
        private readonly DepartamentosContext context;

        public RepositoryDepartamento(DepartamentosContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            List<Departamento> departamentos = context.Departamento.ToList();
            return departamentos;
        }

        public Departamento? GetDepartamento(int id)
        {
            Departamento? departamento = context.Departamento
                .Where(departamentoRow => departamentoRow.Id.Equals(id))
                .FirstOrDefault();

            return departamento;
        }

        public void DeleteDepartamento(int id)
        {
            Departamento? departamento = context.Departamento
                .Where(departamentoRow => departamentoRow.Id.Equals(id))
                .FirstOrDefault();

            if (departamento != null)
            {
                context.Departamento.Remove(departamento);
                context.SaveChanges();
            }
        }

        public void UpdateDepartamento(int id, string nombre, string localidad)
        {
            Departamento? departamento = context.Departamento
                .Where(departamentoRow => departamentoRow.Id.Equals(id))
                .FirstOrDefault();

            if (departamento != null)
            {
                departamento.Id = id;
                departamento.Name = nombre;
                departamento.Localidad = localidad;
                context.SaveChanges();
            }
        }

        public void InsertDepartamento(int id, string nombre, string localidad)
        {
            Departamento? departamento = new Departamento();

            departamento.Id = id;
            departamento.Name = nombre;
            departamento.Localidad = localidad;
            context.SaveChanges();

            context.Departamento.Add(departamento);
            context.SaveChanges();
        }

    }
}
