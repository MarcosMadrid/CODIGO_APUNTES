using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFLogicaCoches.Models;
using WCFLogicaCoches.Repositories;

namespace WCFLogicaCoches
{
    public class CochesClass : ICochesContract
    {
        private RepositoryCoches repositoryCoches;

        public CochesClass()
        {
            repositoryCoches = new RepositoryCoches();
        }

        public Coche GetCoche(int id)
        {
            return repositoryCoches.GetCoche(id);
        }

        public List<Coche> GetCoches()
        {
            return repositoryCoches.GetCoches();
        }
    }
}
