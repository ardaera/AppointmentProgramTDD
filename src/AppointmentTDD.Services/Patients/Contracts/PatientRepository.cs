using AppointmentTDD.Entities;
using AppointmentTDD.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Patients.Contracts
{
    public interface PatientRepository:Repository
    {
        void Add(Patient patient);
        IList<GetPatientDto> GetAll();
        Patient FindId(int id);
        void Delete(Patient patient);

    }
}
