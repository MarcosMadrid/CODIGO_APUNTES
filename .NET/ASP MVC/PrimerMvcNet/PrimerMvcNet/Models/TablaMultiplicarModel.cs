namespace PrimerMvcNet.Models
{
    public class TablaMultiplicarModel
    {
        public List<int> TablaMultiplicarResultados { get; set; }
        public List<string> TablaMultiplicarOperaciones { get; set; }

        public TablaMultiplicarModel() 
        {
            TablaMultiplicarResultados = new List<int>();
            TablaMultiplicarOperaciones = new List<string>();        
        }
    }
}
