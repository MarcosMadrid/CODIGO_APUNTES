
namespace MvcCoreEnfermosEF.Models
{
    public class TrabajadoresModel
    {
        public List<Trabajador>? TrabajadorList { get; set; }
        public int Personas { get; set; }
        public int SumaSalarial { get; set; }
        public int MediaSalarial { get; set; }

        public static implicit operator List<object>(TrabajadoresModel v)
        {
            throw new NotImplementedException();
        }
    }
}
