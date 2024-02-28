using MvcNetCoreEF.Data;
using MvcNetCoreEF.Models;

namespace MvcNetCoreEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Hospital>? GetHospitales()
        {
            List<Hospital>? consulta = context.Hospitals.Select(hospitalRow => hospitalRow).ToList();
            return consulta;
        }

        public Hospital? GetHospital(int id)
        {
            Hospital? consulta = context.Hospitals.
                Where(hospitalRow => hospitalRow.IdHospital.Equals(id))
                .FirstOrDefault();

            return consulta;
        }

        public void InsertHospital(int id, string nombre, string direccion, string telefono, string camas)
        {
            Hospital hospital = new Hospital();

            hospital.IdHospital = id;
            hospital.Nombre = nombre;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            hospital.Direccion = direccion;

            context.Hospitals.Add(hospital);
            context.SaveChanges();
        }

        public void DeleteHospital(int id)
        {
            Hospital? hospital = GetHospital(id);
            if(hospital != null)
            {
                this.context.Hospitals.Remove(hospital);
            }
            context.SaveChanges();
        }

        public void UpdateHospital(int id, string nombre, string direccion, string telefono, string camas)
        {
            Hospital? hospital = GetHospital(id);

            if(hospital != null)
            {
                hospital.IdHospital = id;
                hospital.Nombre = nombre;
                hospital.Direccion = direccion;
                hospital.Telefono = telefono;
                hospital.Camas = camas;
            }

            context.SaveChanges(true);
        }
    }
}
