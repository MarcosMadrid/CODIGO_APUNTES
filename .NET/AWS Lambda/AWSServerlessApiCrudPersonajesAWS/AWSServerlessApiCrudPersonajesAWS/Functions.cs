using Amazon.Lambda.Core;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using AWSServerlessApiCrudPersonajesAWS.Data;
using AWSServerlessApiCrudPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSServerlessApiCrudPersonajesAWS;

public class Functions
{
    private ApiPersonajesAWSContext contextPersonajes;
    public Functions(ApiPersonajesAWSContext context)
    {
        contextPersonajes = context;
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/")]
    public async Task<IHttpResult> Get(ILambdaContext context)
    {
        if (contextPersonajes.Personaje == null)
        {
            return HttpResults.NotFound();
        }
        return HttpResults.Ok(await contextPersonajes.Personaje.ToListAsync());
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/FindPersonaje/{id}")]
    public async Task<IHttpResult> FindPersonaje(string id, ILambdaContext context)
    {
        if (contextPersonajes.Personaje == null)
        {
            return HttpResults.NotFound();
        }
        var personaje = await contextPersonajes.Personaje.FindAsync(id);

        if (personaje == null)
        {
            return HttpResults.NotFound();
        }

        return HttpResults.Ok(personaje);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Put, "/Put/{id}")]
    public async Task<IHttpResult> Put(int id, [FromBody] Personaje personaje, ILambdaContext context)
    {
        if (id != personaje.IdPersonaje)
        {
            return HttpResults.BadRequest();
        }

        contextPersonajes.Entry(personaje).State = EntityState.Modified;

        try
        {
            await contextPersonajes.SaveChangesAsync();
            return HttpResults.Ok(personaje);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            if (!PersonajeExists(id))
            {
                return HttpResults.NotFound();
            }
            else
            {
                return HttpResults.BadRequest(ex.Message);
            }
        }
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Post, "/Post")]
    public async Task<IHttpResult> Post([FromBody] Personaje personaje, ILambdaContext context)
    {
        if (contextPersonajes.Personaje == null)
        {
            return HttpResults.BadRequest("Entity set 'ApiPersonajesAWSContext.Personaje'  is null.");
        }
        contextPersonajes.Personaje.Add(personaje);
        await contextPersonajes.SaveChangesAsync();

        return HttpResults.Created("GetPersonaje", personaje);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Delete, "/Delete/{id}")]
    public async Task<IHttpResult> Delete(int id, ILambdaContext context)
    {
        if (contextPersonajes.Personaje == null)
        {
            return HttpResults.NotFound();
        }
        var personaje = await contextPersonajes.Personaje.FindAsync(id);
        if (personaje == null)
        {
            return HttpResults.NotFound();
        }

        contextPersonajes.Personaje.Remove(personaje);
        await contextPersonajes.SaveChangesAsync();

        return HttpResults.Ok();
    }

    private bool PersonajeExists(int id)
    {
        return (contextPersonajes.Personaje?.Any(e => e.IdPersonaje == id)).GetValueOrDefault();
    }
}
