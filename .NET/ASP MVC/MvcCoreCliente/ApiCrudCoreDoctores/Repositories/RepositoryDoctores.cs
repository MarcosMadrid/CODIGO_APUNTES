using ApiCrudCoreDoctores.Data;
using ApiCrudCoreDoctores.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ApiCrudCoreDoctores.Repositories
{
    public class RepositoryDoctores : IRepositoryDoct
    {
        ContextDoctores contextDoctores;

        public RepositoryDoctores(ContextDoctores contextDoctores)
        {
            this.contextDoctores = contextDoctores;
        }

        public async Task DeleteDoctor(int id)
        {
            Doctor? doct = await GetDoctor(id)!;
            contextDoctores.Remove(doct);
            await contextDoctores.SaveChangesAsync();
        }

        public async Task<Doctor?> GetDoctor(int id)
        {
            return
                await contextDoctores.Doctores.FirstOrDefaultAsync(doctor => doctor.IdDoctor.Equals(id));
        }

        public async Task<List<Doctor>?> GetDoctores()
        {
            return
                await contextDoctores.Doctores.ToListAsync();
        }

        public async Task PostDoctor(Doctor doctor)
        {
            int idMax = await contextDoctores.Doctores.MaxAsync(doc => doc.IdDoctor);
            doctor.IdDoctor = idMax + 1;
            contextDoctores.Doctores.Add(doctor);
            await contextDoctores.SaveChangesAsync();
        }

        public async Task PostDoctor(int idHospital, string apellido, string especialidad, int salario)
        {
            Doctor doctor = new Doctor()
            {
                IdHospital = idHospital,
                Apellido = apellido,
                Especialidad = especialidad,
                Salario = salario
            };
            int idMax = await contextDoctores.Doctores.MaxAsync(doc => doc.IdDoctor);
            doctor.IdDoctor = idMax + 1;
            contextDoctores.Doctores.Add(doctor);
            await contextDoctores.SaveChangesAsync();
        }

        public async Task PutDoctor(Doctor doctor)
        {
            Doctor? doctorRow = await GetDoctor(doctor.IdDoctor)!;
            doctorRow = doctor;
            await contextDoctores.SaveChangesAsync();
        }

        public async Task PutDoctor(int idHospital, int idDoctor, string apellido, string especialidad, int salario)
        {
            Doctor? doctorRow = await GetDoctor(idDoctor)!;
            Doctor newDoctor = new Doctor()
            {
                IdHospital = idHospital,
                IdDoctor = idDoctor,
                Apellido = apellido,
                Especialidad = especialidad,
                Salario = salario
            };
            doctorRow = newDoctor;
            await contextDoctores.SaveChangesAsync();
        }
    }
}
