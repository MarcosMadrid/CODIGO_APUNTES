using ConsoleAppApiEmpleadosHospital.Services;

string urlApi = "https://localhost:7169";
ServiceEmpleadosHospital serviceEmpleados = new ServiceEmpleadosHospital(urlApi);

Console.WriteLine("Apellido:");
string apellido = Console.ReadLine()!;
Console.WriteLine("Password:");
string password = Console.ReadLine()!;
string response = await serviceEmpleados.GetTokenAsync(apellido, password);


Console.WriteLine(response);