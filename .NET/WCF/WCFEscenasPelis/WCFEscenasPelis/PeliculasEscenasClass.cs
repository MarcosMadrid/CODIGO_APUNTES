using System.Collections.Generic;
using WCFEscenasPelis.Repositories;

namespace WCFEscenasPelis
{
    public class PeliculasEscenasClass : IPeliculasContract
    {
        RepositoryPelis repositoryPelis;

        public PeliculasEscenasClass()
        {
            this.repositoryPelis = new RepositoryPelis();
        }

        public List<Pelicula> GetPeliculaEscenas(int id)
        {
            return repositoryPelis.GetPeliculaEscenas(id);
        }

        public List<Pelicula> GetPeliculas()
        {
            return repositoryPelis.GetPeliculas();
        }
    }
}
