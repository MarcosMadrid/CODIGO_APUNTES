using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Core;
using AWSServerlessPersonas.Models;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSServerlessPersonas;

public class Functions
{
    public List<Persona> personasList;

    /// <summary>
    /// Default constructor that Lambda will invoke.
    /// </summary>
    public Functions()
    {
        this.personasList = new List<Persona>();
        Persona p = new Persona
        {
            IdPersona = 1,
            Nombre = "Adrian",
            Email = "adrian@gmail.com",
            Edad = 24
        };
        this.personasList.Add(p);
        p = new Persona
        {
            IdPersona = 2,
            Nombre = "Lucia",
            Email = "lucia@gmail.com",
            Edad = 22
        };
        this.personasList.Add(p);
        p = new Persona
        {
            IdPersona = 3,
            Nombre = "Antonia",
            Email = "antonia@gmail.com",
            Edad = 44
        };
        this.personasList.Add(p);
        p = new Persona
        {
            IdPersona = 4,
            Nombre = "Carlos",
            Email = "carlos@gmail.com",
            Edad = 47
        };
        this.personasList.Add(p);
        p = new Persona
        {
            IdPersona = 5,
            Nombre = "Pedro",
            Email = "pedro@gmail.com",
            Edad = 23
        };
        this.personasList.Add(p);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/")]
    public IHttpResult Get(ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");
        string json = JsonConvert.SerializeObject(this.personasList);
        return HttpResults.Ok(json);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/find/{id}")]
    public IHttpResult Find(int id, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");
        Persona persona = this.personasList[id + 1];
        string json = JsonConvert.SerializeObject(persona);
        return HttpResults.Ok(json);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Post, "/post")]
    public IHttpResult Post([FromBody] Persona persona, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");
        string json = JsonConvert.SerializeObject(persona);
        return HttpResults.Ok(json);
    }
}
