using System.Collections.Generic;
using System.ServiceModel;

namespace WCFEscenasPelis
{
    [ServiceContract]
    public interface IPeliculasContract
    {
        [OperationContract]
        List<Pelicula> GetPeliculas();

        [OperationContract]
        List<Pelicula> GetPeliculaEscenas(int id);
    }
}
