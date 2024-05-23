using ConsoleAWSSecrets.Helpers;
using ConsoleAWSSecrets.Models;
using Newtonsoft.Json;

Console.WriteLine("Ejemplo secrets manager");
string miSecreto = await HelperSecretManager.GetSecret();
Console.WriteLine(miSecreto);

KeysModel model = JsonConvert.DeserializeObject<KeysModel>(miSecreto);
Console.WriteLine("MySql: " + model.ConnectionSql);
