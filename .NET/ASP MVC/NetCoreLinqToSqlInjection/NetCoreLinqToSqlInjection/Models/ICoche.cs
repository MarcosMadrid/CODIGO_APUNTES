namespace NetCoreLinqToSqlInjection.Models
{
    public interface ICoche
    {
        string Marca { get; set; }
        string Modelo { get; set; }
        string Img { get; set; }
        int Velocidad { get; set; }
        int VelocidadMax { get; set; }

        void Acelerar();
        void Frenar();
    }
}
