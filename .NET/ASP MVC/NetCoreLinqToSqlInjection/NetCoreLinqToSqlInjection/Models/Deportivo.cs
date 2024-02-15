namespace NetCoreLinqToSqlInjection.Models
{
    public class Deportivo : ICoche
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Img { get; set; }
        public int Velocidad { get; set; }
        public int VelocidadMax { get; set; }

        public Deportivo()
        {
            Marca = "Ford";
            Modelo = "Ford Mustang GT";
            Img = "ford-mustang-gt-sports-car-supercar.jpg";
            Velocidad = 0;
            VelocidadMax = 250;
        }


        public void Acelerar()
        {
            Velocidad += 30;
            if (Velocidad > VelocidadMax)
            {
                Velocidad = VelocidadMax;
            }
        }

        public void Frenar()
        {
            Velocidad -= 30;
            if (Velocidad < 0)
            {
                Velocidad = 0;
            }
        }
    }
}
