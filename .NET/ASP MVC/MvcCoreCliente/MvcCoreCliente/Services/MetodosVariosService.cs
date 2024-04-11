using ServiceMetodosVarios;

namespace MvcCoreCliente.Services
{
    public class MetodosVariosService
    {
        MetodosVariadosClient metodosVarios;
        public MetodosVariosService()
        {
            this.metodosVarios = new MetodosVariadosClient();
        }

        public async Task<string> GetSaludo(string name)
        {
            return
                await metodosVarios.GetSaludoAsync(name);
        }

        public async Task<int[]> GetMultiplicar(int num)
        {
            return
                await metodosVarios.GetTablaMultiplicarAsync(num);
        }
    }
}
