using Amazon.Lambda.Core;
using AWSLambda1.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Net;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]


public class Function
{

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public string FunctionHandler(IdEmpleado emp, ILambdaContext context)
    {
        int idempleado = 0;
        try
        {
            idempleado = emp.Id;
        }
        catch (FormatException ex)
        {
            return ex.Message;
        }

        //CADENA DE CONEXION
        string connectionString = context.ClientContext.Environment["connectionString"]!.ToString();
        SqlConnection cn = new SqlConnection(connectionString);
        SqlCommand com = new SqlCommand();
        string sqlUpdate = "UPDATE EMP SET SALARIO = SALARIO + 1 "
            + " WHERE EMP_NO=" + idempleado;
        com.Connection = cn;
        com.CommandType = System.Data.CommandType.Text;
        com.CommandText = sqlUpdate;
        cn.Open();
        com.ExecuteNonQuery();
        string sqlSelect = "select * from EMP where EMP_NO="
            + idempleado;
        com.CommandText = sqlSelect;
        SqlDataReader reader = com.ExecuteReader();
        string mensaje = "";
        if (reader.Read())
        {
            mensaje = "El empleado " + reader["APELLIDO"].ToString()
                + " con oficio "
                + reader["OFICIO"].ToString() + " ha incrementado "
                + " su salario a " + reader["SALARIO"].ToString();
            reader.Close();
        }
        else
        {
            mensaje = "No existe el empleado con ID " + idempleado;
        }
        cn.Close();

        return mensaje;

    }
}
