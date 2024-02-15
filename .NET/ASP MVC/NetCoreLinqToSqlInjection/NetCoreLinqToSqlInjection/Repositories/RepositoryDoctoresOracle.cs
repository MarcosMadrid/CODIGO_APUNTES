using NetCoreLinqToSqlInjection.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace NetCoreLinqToSqlInjection.Repositories
{
    public class RepositoryDoctoresOracle : IRepositoryBBDDConnectorDocotres
    {
        private OracleConnection oracleConnection = new OracleConnection("Data Source=LOCALHOST:1521/XE; Persist Security Info=True;User Id=SYSTEM;Password=oracle");
        private DataTable tableDoctores = new DataTable();
        private OracleCommand oracleCommand;
        private OracleDataReader? oracleDataReader;

        public RepositoryDoctoresOracle()
        {
            oracleCommand = oracleConnection.CreateCommand();
            string sql = "SELECT * FROM DOCTOR";
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sql, oracleConnection);
            oracleDataAdapter.Fill(tableDoctores);
        }

        public List<Doctor>? GetDoctors()
        {
            List<Doctor>? doctors = new List<Doctor>();

            string sql = "select * from DOCTOR";
            oracleCommand.CommandText = sql;

            oracleConnection.Open();
            oracleDataReader = oracleCommand.ExecuteReader();
            while (oracleDataReader.Read())
            {
                Doctor doctor = new Doctor();

                doctor.HOSPITAL_COD = oracleDataReader["HOSPITAL_COD"].ToString();
                doctor.DOCTOR_NO = oracleDataReader["DOCTOR_NO"].ToString();
                doctor.APELLIDO = oracleDataReader["APELLIDO"].ToString();
                doctor.ESPECIALIDAD = oracleDataReader["ESPECIALIDAD"].ToString();
                doctor.SALARIO = int.Parse(oracleDataReader["SALARIO"].ToString());

                doctors.Add(doctor);
            }
            oracleConnection.Close();

            if (doctors.Count() <= 0)
            {
                return null;
            }

            return doctors;
        }

        public async void InsertDoctor(string id, string apellido, string especialidad, int salario, string idHospital)
        {
            string sql = "INSERT INTO DOCTOR VALUES (:IDHOSPITAL, :IDDOCTOR, :APELLIDO, " +
                ":ESPECIALIDAD , :SALARIO)";
            oracleCommand.CommandText = sql;
            this.oracleCommand.CommandType = CommandType.Text;

            oracleCommand.Parameters.Clear();
            
            this.oracleCommand.Parameters.Add(":IDHOSPITAL", idHospital);
            this.oracleCommand.Parameters.Add(":IDDOCTOR", id);
            this.oracleCommand.Parameters.Add(":APELLIDO", apellido);
            this.oracleCommand.Parameters.Add(":ESPECIALIDAD", especialidad);
            this.oracleCommand.Parameters.Add(":SALARIO", salario);


            await oracleConnection.OpenAsync();
            await oracleCommand.ExecuteNonQueryAsync();
            await oracleConnection.CloseAsync();

            oracleCommand.Parameters.Clear();
        }

        public async Task<Doctor> GetDoctorAsync(string id)
        {
            string sql = "SELECT * FROM DOCTOR WHERE DOCTOR_NO = @IDDOCTOR";

            oracleCommand.CommandText = sql;
            oracleCommand.Parameters.Clear();

            Doctor doctor = new Doctor();

            await oracleConnection.OpenAsync();
            await oracleCommand.ExecuteNonQueryAsync();
            await oracleConnection.CloseAsync();

            return doctor;
        }

        public async void DeleteDoctor(string id)
        {
            string sql = "DELETE_DOCTOR";
            oracleCommand.CommandText = sql;
            oracleCommand.CommandType = CommandType.StoredProcedure;

            oracleCommand.Parameters.Clear();
            this.oracleCommand.Parameters.Add("IDDOCTOR", id);

            await oracleConnection.OpenAsync();
            await oracleCommand.ExecuteNonQueryAsync();
            await oracleConnection.CloseAsync();
        }

        public List<string?>? GetEspecialidadesDoctores()
        {
            List<string?> especialidades = tableDoctores.AsEnumerable()
                .Select(doctorRow =>
                    {
                        return doctorRow.Field<string>("ESPECIALIDAD");
                    })
                .Distinct()
                .ToList();

            if (especialidades.Count() <= 0)
            {
                return null;
            }
            return especialidades;
        }

        public List<Doctor>? GetDoctorsEspecialidad(string especialidad)
        {
            List<Doctor> doctors = new List<Doctor>();
            string sql = "select * from DOCTOR where ESPECIALIDAD = :ESPECIALIDAD";
            this.oracleCommand.CommandText = sql;

            this.oracleCommand.Parameters.Clear();
            this.oracleCommand.Parameters.Add(":ESPECIALIDAD", especialidad);

            oracleConnection.Open();
            this.oracleDataReader = oracleCommand.ExecuteReader();
            while (oracleDataReader.Read())
            {
                Doctor doctor = new Doctor();

                doctor.HOSPITAL_COD = oracleDataReader["HOSPITAL_COD"].ToString();
                doctor.DOCTOR_NO = oracleDataReader["DOCTOR_NO"].ToString();
                doctor.APELLIDO = oracleDataReader["APELLIDO"].ToString();
                doctor.ESPECIALIDAD = oracleDataReader["ESPECIALIDAD"].ToString();
                doctor.SALARIO = int.Parse(oracleDataReader["SALARIO"].ToString());

                doctors.Add(doctor);
            }
            this.oracleConnection.Close();

            this.oracleCommand.Parameters.Clear();

            if (doctors.Count() <= 0)
            {
                return null;
            }
            return doctors;
        }
    }
}
