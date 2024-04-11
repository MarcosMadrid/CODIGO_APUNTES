// See https://aka.ms/new-console-template for more information
using ProyectoNugetCoches;

Console.WriteLine("Hello, World!");
Garaje garaje = new Garaje();
List<Coche> coches = garaje.GetCoches();
foreach (Coche coche in coches)
{
    Console.WriteLine(coche.Marca + "|" + coche.Modelo);
}