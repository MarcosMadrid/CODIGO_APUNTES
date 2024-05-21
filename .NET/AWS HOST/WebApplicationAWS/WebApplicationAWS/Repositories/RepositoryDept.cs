using Microsoft.EntityFrameworkCore;
using WebApplicationAWS.Data;
using WebApplicationAWS.Models;

namespace WebApplicationAWS.Repositories
{
    public class RepositoryDept
    {
        private ContextDept ContextDept;

        public RepositoryDept(ContextDept contextDept)
        {
            ContextDept = contextDept;
        }

        public async Task<List<Departamento>> GetDepartamentos()
        {
            return
                await ContextDept.Departamentos.ToListAsync();
        }

        public async Task<Departamento?> GetDepartamento(int id)
        {
            return
                await ContextDept.Departamentos
                .FirstOrDefaultAsync(dept => dept.Id.Equals(id));
        }

        public async Task<Departamento> DeleteDept(int id)
        {
            Departamento? dept = await ContextDept.Departamentos.FirstOrDefaultAsync(dept => dept.Id.Equals(id));
            if (dept == null)
            {
                return null;
            }
            ContextDept.Remove(dept);
            await ContextDept.SaveChangesAsync();
            return dept;
        }

        public async Task<Departamento> UpdateDept(int id, string? nombre, string? loc)
        {
            Departamento? dept = await ContextDept.Departamentos.FirstOrDefaultAsync(dept => dept.Id.Equals(id));
            if (dept == null)
            {
                return null;
            }
            if (nombre != null)
            {
                dept.Nombre = nombre;
            }
            if (loc != null)
            {
                dept.Localidad = loc;
            }
            await ContextDept.SaveChangesAsync();
            return dept;
        }

        public async Task<Departamento> CreateDept(string? nombre, string? loc)
        {
            Departamento? dept = new Departamento()
            {
                Id = await ContextDept.Departamentos.Select(dept => dept.Id).MaxAsync() + 1,
                Nombre = nombre,
                Localidad = loc
            };

            if (nombre != null)
            {
                dept.Nombre = nombre;
            }

            if (loc != null)
            {
                dept.Localidad = loc;
            }

            await ContextDept.AddAsync(dept);
            await ContextDept.SaveChangesAsync();
            return dept;
        }
    }
}
