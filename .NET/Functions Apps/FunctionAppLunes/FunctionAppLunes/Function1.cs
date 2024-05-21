using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppLunes
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            NameValueCollection query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
            var response = req.CreateResponse(HttpStatusCode.OK);
            try
            {
                int idEmpleado = int.Parse(query["idempleado"]!);
                string connectionString = @"Data Source=marcossql.database.windows.net;Initial Catalog=AZURETAJAMAR;User ID=adminsql;Password=Admin123;Connect Timeout=30;Encrypt=True;TrustServerCertificate=Yes;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                string command = "UPDATE EMP SET SALARIO = SALARIO + 1 "
                 + " WHERE EMP_NO=" + idEmpleado;
                sqlCommand.CommandText = command;
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();

                sqlCommand.CommandText = "SELECT * FROM EMP WHERE EMP_NO = " + idEmpleado;
                await sqlConnection.OpenAsync();

                string mensaje = "";
                using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        mensaje = "El empleado " + reader["APELLIDO"].ToString()
                         + " con oficio "
                         + reader["OFICIO"].ToString() + " ha incrementado "
                         + " su salario a " + reader["SALARIO"].ToString();
                    }
                    reader.Close();

                }
                await sqlConnection.CloseAsync();
                if (string.IsNullOrEmpty(mensaje))
                {
                    response = req.CreateResponse(HttpStatusCode.NotFound);
                    response.WriteString("El empleado id " + idEmpleado +", no existe");

                }
                    response.WriteString(mensaje);
            }
            catch (Exception ex)
            {
                response = req.CreateResponse(HttpStatusCode.BadRequest);
                response.WriteString(ex.Message);
            }

            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");


            return response;
        }
    }
}
