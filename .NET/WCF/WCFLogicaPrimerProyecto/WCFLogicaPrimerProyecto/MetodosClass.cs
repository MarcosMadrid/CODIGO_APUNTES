using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogicaPrimerProyecto
{
    public class MetodosClass : IMetodosVariados
    {
        public int GetNumeroDoble(int numero)
        {
            return numero * 2;
        }

        public string GetSaludo(string nombre)
        {
            return "hOLA" + nombre;
        }

        public List<int> GetTablaMultiplicar(int numero)
        {
            List<int> lista = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                lista.Add(i*numero);
            }
            return lista;
        }

        public string MetodoInvisible()
        {
            return "void";
        }
    }
}
