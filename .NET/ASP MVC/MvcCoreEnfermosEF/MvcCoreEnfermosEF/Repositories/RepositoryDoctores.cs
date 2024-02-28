using Microsoft.AspNetCore.Http.HttpResults;
using MvcCoreEnfermosEF.Data;
using MvcCoreEnfermosEF.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace MvcCoreEnfermosEF.Repositories
{

    #region PROCEDURES DOCTOR
    //CREATE OR ALTER PROCEDURE PD_ESPECIALIDADES_DOCTORES
    //AS
    //    BEGIN
    //        SELECT DISTINCT(ESPECIALIDAD) FROM DOCTOR
    //    END
    //GO

    //CREATE OR ALTER PROCEDURE PD_SUBIR_SALARIO_DOCTORES_ESPECIALIDAD(@especialidad nvarchar(50), @incremento int)
    //AS
    //    BEGIN
    //        UPDATE DOCTOR SET SALARIO = SALARIO + @incremento WHERE ESPECIALIDAD = @especialidad
    //    END
    //GO

    //CREATE OR ALTER PROCEDURE PD_DOCTORES_ESPECIALIDAD(@especialidad nvarchar(50))
    //AS
    //    BEGIN
    //        SELECT* FROM DOCTOR WHERE DOCTOR.ESPECIALIDAD = @especialidad
    //    END
    //GO
    #endregion

    public class RepositoryDoctores
    {
        HospitalBBDDContext context;
        public RepositoryDoctores(HospitalBBDDContext context)
        {
            this.context = context;
        }

        public List<Doctor>? GetDoctors()
        {
            List<Doctor>? doctors = context.Doctores.ToList();

            if (doctors.Count() <= 0)
            {
                return null;
            }

            return doctors;
        }

        public Doctor? GetDoctor(int id)
        {
            return context.Doctores.Where(doctorRow => doctorRow.Equals(id)).FirstOrDefault();
        }

        public List<string>? GetDoctorEspecialidades()
        {
            List<string> especialidades = new List<string>();
            string sql = "PD_ESPECIALIDADES_DOCTORES";
            using (DbCommand command = context.Doctores.CreateDbCommand())
            {
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                command.Connection.Open();
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string? especialidad = reader["ESPECIALIDADES"].ToString();
                    especialidades.Add(especialidad);
                }
                reader.Close();
                command.Connection.Close();
            }

            if (especialidades.Count() <= 0)
            {
                return null;
            }

            return especialidades;
        }

        public List<Doctor>? DoctoresEspecialidad(string especialidad)
        {
            string sql = "PD_DOCTORES_ESPECIALIDAD @especialidad";
            SqlParameter sqlEspecialidad = new SqlParameter("especialidad", especialidad);
            List<Doctor>? doctors = (List<Doctor>?)context.Doctores.FromSqlRaw(sql, sqlEspecialidad).AsEnumerable().ToList();
            return doctors;
        }

        public void SubirSalarioDoctoresEspecialidad(string especialidad, double incremento)
        {
            string sql = "PD_SUBIR_SALARIO_DOCTORES_ESPECIALIDAD @especialidad, @incremento";
            SqlParameter sqlEspecialidad = new SqlParameter("especialidad", especialidad);
            SqlParameter sqlIncremento = new SqlParameter("incremento", incremento);
            context.Database.ExecuteSqlRaw(sql, sqlEspecialidad, sqlIncremento);
        }

    }
}
