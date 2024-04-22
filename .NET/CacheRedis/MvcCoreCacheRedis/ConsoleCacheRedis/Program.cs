using ConsoleCacheRedis.Models;
using ConsoleCacheRedis.Services;

Console.WriteLine("Test cache service");
ServiceCacheRedis serviceCache = new ServiceCacheRedis();
List<Producto>? products = new List<Producto>();

string? option = "";
while (option != "0")
{
    try
    {
        Console.WriteLine("0 para salir");
        Console.WriteLine("1 para ver cahce favoraitos");
        option = Console.ReadLine();
        switch (option)
        {
            case "1":
                products = await serviceCache.GetProductos();
                if (products != null)
                {
                    foreach (Producto prod in products)
                    {
                        Console.WriteLine(prod.IdProducto + "|" + prod.Nombre);
                    }
                }
                break;
            default:
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        option = Console.ReadLine();
    }
}