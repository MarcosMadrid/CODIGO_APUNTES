namespace NetCoreLinqToSqlInjection.Models
{
    public class Coche : ICoche
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Img { get; set; }
        public int Velocidad { get; set; }
        public int VelocidadMax { get; set; }

        public Coche()
        {
            Marca = "ToySurus";
            Modelo = "Terrraneitor";
            Img = "terraneitor.jpg";
            Velocidad = 0;
            VelocidadMax = 130;
        }

        public void Acelerar()
        {
            Velocidad += 10;
            if (Velocidad > VelocidadMax)
            {
                Velocidad = VelocidadMax;
            }
        }

        public void Frenar()
        {
            Velocidad -= 10;
            if (Velocidad < 0)
            {
                Velocidad = 0;
            }
        }
    }
}
