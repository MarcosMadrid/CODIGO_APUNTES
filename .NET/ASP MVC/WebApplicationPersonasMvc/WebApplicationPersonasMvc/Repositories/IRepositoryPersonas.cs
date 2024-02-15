using WebApplicationPersonasMvc.Models;

namespace WebApplicationPersonasMvc.Repositories
{
    public interface IRepositoryPersonas
    {
        List<Personaje>? GetPersonajes();
        Personaje GetPersonaje(int id);
        void DeletePersonaje(int id);
        void UpdatePersonaje(int id_personaje, string nombre, string imagen);
        void InsertPersonaje(int id_personaje, string nombre, string imagen);
    }
}
