using Microsoft.AspNetCore.Http.HttpResults;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System;
using System.Data;
using WebApplicationPersonasMvc.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace WebApplicationPersonasMvc.Repositories
{

    #region
    // UPDATE PROCEDURE PERSONAJE
    //CREATE OR REPLACE PROCEDURE PD_UPDATE_PERSONAJE
    //(id_personaje PERSONAJES.IDPERSONAJE%TYPE , nombre PERSONAJES.PERSONAJE%TYPE , imagen PERSONAJES.IMAGEN%TYPE)
    //AS
    //BEGIN
    //    UPDATE PERSONAJES SET IDPERSONAJE = id_personaje, PERSONAJE = nombre, IMAGEN = imagen WHERE IDPERSONAJE = id_personaje;
    //    COMMIT;
    //END;
    #endregion
    public class RepositoryOraclePersonaje : IRepositoryPersonas
    {
        private OracleConnection connection = new OracleConnection("Data Source=LOCALHOST:1521/XE; Persist Security Info=True;User Id=SYSTEM;Password=oracle");
        private OracleCommand command;
        private OracleDataReader? reader;
        private DataTable tablePersonajes = new DataTable();

        public RepositoryOraclePersonaje()
        {
            command = connection.CreateCommand();

            string sql = "SELECT * FROM PERSONAJES";
            OracleDataAdapter dataAdapter = new OracleDataAdapter(sql, connection);
            dataAdapter.Fill(tablePersonajes);
        }

        public void DeletePersonaje(int id)
        {
            string sql = "DELETE FROM PERSONAJES WHERE IDPERSONAJE = :IDPERSONAJE";
            command.CommandText = sql;
            command.Parameters.Clear();

            command.Parameters.Add("IDPERSONAJE", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Personaje GetPersonaje(int id)
        {
            Personaje personaje;
            string sql = "SELECT * FROM PERSONAJES WHERE IDPERSONAJE = :IDPERSONAJE";
            command.CommandText = sql;

            command.Parameters.Clear();
            command.Parameters.Add("IDPERSONAJE", id);

            connection.Open();
            reader = command.ExecuteReader();
            personaje = new Personaje();
            while (reader.Read())
            {
                personaje.IDPERSONAJE = int.Parse(reader["IDPERSONAJE"].ToString());
                personaje.Nombre = reader["PERSONAJE"].ToString();
                personaje.Imagen = reader["IMAGEN"].ToString();
            }
            connection.Close();

            command.Parameters.Clear();

            return personaje;
        }

        public List<Personaje>? GetPersonajes()
        {
            List<Personaje>? personajes;
            personajes = tablePersonajes.AsEnumerable()
                .Select(personajeRow =>
                {
                    Personaje personaje = new Personaje();

                    personaje.IDPERSONAJE = personajeRow.Field<int>("IDPERSONAJE");
                    personaje.Nombre = personajeRow.Field<string?>("PERSONAJE");
                    personaje.Imagen = personajeRow.Field<string?>("IMAGEN");

                    return personaje;
                })
                .ToList();

            if (personajes.Count() <= 0)
            {
                return null;
            }
            return personajes;
        }

        public void InsertPersonaje(int id_personaje, string nombre, string imagen)
        {
            string sql = "INSERT INTO PERSONAJES VALUES (:IDPERSONAJE, :NOMBRE, :IMAGEN)";
            command.CommandText = sql;

            command.Parameters.Clear();
            command.Parameters.Add("IDPERSONAJE", id_personaje);
            command.Parameters.Add("NOMBRE", nombre);
            command.Parameters.Add("IMAGEN", imagen);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            command.Parameters.Clear();
        }

        public void UpdatePersonaje(int id_personaje, string nombre, string imagen)
        {
            string procedure = "PD_UPDATE_PERSONAJE";
            command.CommandText = procedure;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Clear();
            command.Parameters.Add("id_personaje", id_personaje);
            command.Parameters.Add("nombre", nombre);
            command.Parameters.Add("imagen", imagen);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            command.Parameters.Clear();
        }
    }
}
