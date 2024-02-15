using NetCoreLinqToSqlInjection.Models;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreLinqToSqlInjection.Repositories
{
    public class RepositoryDoctoresSQLServer : IRepositoryBBDDConnectorDocotres
    {
        private SqlConnection cn = new SqlConnection("Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=HOSPITALBBDD;User ID=SA;Password=MCSD2023");
        private DataTable tableDoctores = new DataTable();
        private SqlCommand cmd;
        private SqlDataReader? reader;

        public RepositoryDoctoresSQLServer()
        {
            string sql = "SELECT * FROM DOCTOR";
            cmd = cn.CreateCommand();
            cmd.CommandText = sql;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
            dataAdapter.Fill(tableDoctores);
        }

        public List<Doctor>? GetDoctors()
        {
            List<Doctor> doctors;
            doctors = tableDoctores.AsEnumerable()
                .Select(doctorRow =>
                {
                    Doctor doctor = new Doctor();

                    doctor.APELLIDO = doctorRow.Field<string?>("APELLIDO");
                    doctor.ESPECIALIDAD = doctorRow.Field<string?>("ESPECIALIDAD");
                    doctor.DOCTOR_NO = doctorRow.Field<string?>("DOCTOR_NO");
                    doctor.HOSPITAL_COD = doctorRow.Field<string?>("HOSPITAL_COD");
                    doctor.SALARIO = doctorRow.Field<int>("SALARIO");

                    return doctor;

                })
                .ToList();

            if (doctors.Count() == 0 || doctors == null)
            {
                return null;
            }
            return doctors;
        }

        public async void InsertDoctor(string id, string apellido, string especialidad, int salario, string idHospital)
        {
            string sql = "INSERT INTO DOCTOR VALUES (@IDHOSPITAL, @IDDOCTOR, @APELLIDO, " +
                "@ESPECIALIDAD ,@SALARIO);";
            cmd.CommandText = sql;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("IDHOSPITAL", idHospital);
            cmd.Parameters.AddWithValue("IDDOCTOR", id);
            cmd.Parameters.AddWithValue("APELLIDO", apellido);
            cmd.Parameters.AddWithValue("ESPECIALIDAD", especialidad);
            cmd.Parameters.AddWithValue("SALARIO", salario);

            await cn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await cn.CloseAsync();

            cmd.Parameters.Clear();
        }

        public async Task<Doctor> GetDoctorAsync(string id)
        {
            string sql = "SELECT * FROM DOCTOR WHERE DOCTOR_NO = @IDDOCTOR";
            cmd.CommandText = sql;

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("IDDOCTOR", id);

            Doctor doctor = new Doctor();

            await cn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await cn.CloseAsync();

            return doctor;
        }

        public async void DeleteDoctor(string id)
        {
            string sql = "DELETE FROM DOCTOR WHERE DOCTOR_NO = @IDDOCTOR";

            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("IDDOCTOR", id);

            await cn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await cn.CloseAsync();
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
            string sql = "select * from DOCTOR where ESPECIALIDAD=@ESPECIALIDAD";
            this.cmd.CommandText = sql;

            this.cmd.Parameters.Clear();
            SqlParameter especialidadParam = new SqlParameter("ESPECIALIDAD", especialidad);
            this.cmd.Parameters.Add(especialidadParam);

            this.cn.OpenAsync();
            this.reader = this.cmd.ExecuteReader();
            while (reader.Read())
            {
                Doctor doctor = new Doctor();

                doctor.HOSPITAL_COD = reader["HOSPITAL_COD"].ToString();
                doctor.DOCTOR_NO = reader["DOCTOR_NO"].ToString();
                doctor.APELLIDO = reader["APELLIDO"].ToString();
                doctor.ESPECIALIDAD = reader["ESPECIALIDAD"].ToString();
                doctor.SALARIO = int.Parse(reader["SALARIO"].ToString());

                doctors.Add(doctor);
            }
            this.cn.Close();

            this.cmd.Parameters.Clear();   
            
            if (doctors.Count() <= 0)
            {
                return null;
            }
            return doctors;
        }
    }
}
