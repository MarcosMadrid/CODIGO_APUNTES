using MvcCoreEnfermosEF.Data;
using MvcCoreEnfermosEF.Models;

namespace MvcCoreEnfermosEF.Repositories
{
    public class EnfermoRepository
    {
        private readonly EnfermoContext context;

        public EnfermoRepository(EnfermoContext context)
        {
            this.context = context;
        }

        public List<Enfermo> GetEnfermos()
        {
            List<Enfermo>? consulta = context.Enfermo.Select(enfermoRow => enfermoRow).ToList();
            return consulta;
        }
    }
}