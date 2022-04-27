using AppointmentTDD.Entities;
using AppointmentTDD.Services.Patients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Persistence.EF.Patients
{
    public class EFPatientRepository : PatientRepository
    {
        private readonly EFDataContext _dataContext;
        public EFPatientRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(Patient patient)
        {
            _dataContext.Patients.Add(patient);
        }

        public void Delete(Patient patient)
        {
            _dataContext.Patients.Remove(patient);
        }

        public Patient FindId(int id)
        {
            return _dataContext.Patients.Find(id);
        }

        public IList<GetPatientDto> GetAll()
        {
            return _dataContext.Patients.Select(x => new GetPatientDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Appointments = x.Appointments
            }).ToList();
        }
    }
}
