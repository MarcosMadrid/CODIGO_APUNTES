using System.Data.SqlClient;
using WebApplicationPersonasMvc.Models;

namespace WebApplicationPersonasMvc.Repositories
{
    public class RepositorySQLServerPersonaje : IRepositoryPersonas
    {
        SqlConnection connection = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;User ID=SA;Encrypt=True;Trust Server Certificate=True");

        public void DeletePersonaje(int id)
        {
            throw new NotImplementedException();
        }

        public Personaje GetPersonaje(int id)
        {
            throw new NotImplementedException();
        }

        public List<Personaje> GetPersonajes()
        {
            throw new NotImplementedException();
        }

        public void InsertPersonaje(int id_personaje, string nombre, string imagen)
        {
            throw new NotImplementedException();
        }

        public void UpdatePersonaje(int id_personaje, string nombre, string imagen)
        {
            throw new NotImplementedException();
        }
    }
}
