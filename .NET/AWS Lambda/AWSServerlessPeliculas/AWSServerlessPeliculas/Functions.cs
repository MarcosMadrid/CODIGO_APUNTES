using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using AWSServerlessPeliculas.Repositories;
using AWSServerlessPeliculas.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSServerlessPeliculas;

public class Functions
{
    private RepositoryPelicula repositoryPelicula;
    /// <summary>
    /// Default constructor that Lambda will invoke.
    /// </summary>
    public Functions(RepositoryPelicula repositoryPelicula)
    {
        this.repositoryPelicula = repositoryPelicula;
    }


    /// <summary>
    /// A Lambda function to respond to HTTP Get methods from API Gateway
    /// </summary>
    /// <remarks>
    /// This uses the <see href="https://github.com/aws/aws-lambda-dotnet/blob/master/Libraries/src/Amazon.Lambda.Annotations/README.md">Lambda Annotations</see> 
    /// programming model to bridge the gap between the Lambda programming model and a more idiomatic .NET model.
    /// 
    /// This automatically handles reading parameters from an APIGatewayProxyRequest
    /// as well as syncing the function definitions to serverless.template each time you build.
    /// 
    /// If you do not wish to use this model and need to manipulate the API Gateway 
    /// objects directly, see the accompanying Readme.md for instructions.
    /// </remarks>
    /// <param name="context">Information about the invocation, function, and execution environment</param>
    /// <returns>The response as an implicit <see cref="APIGatewayProxyResponse"/></returns>
    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/")]
    public async Task<IHttpResult> GetPeliculas(ILambdaContext context)
    {
        List<Pelicula> peliculas = await repositoryPelicula.GetPeliculas();
        return HttpResults.Ok(peliculas);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/GetPeliculasActores/{actor}")]
    public async Task<IHttpResult> GetPeliculasActores(string actor, ILambdaContext context)
    {
        List<Pelicula> peliculas = await repositoryPelicula.GetPeliculasActor(actor);
        return HttpResults.Ok(peliculas);
    }
}
