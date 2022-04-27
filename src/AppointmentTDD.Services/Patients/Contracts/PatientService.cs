using AppointmentTDD.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Patients.Contracts
{
    public interface PatientService : Service
    {
        void Add(AddPatientDto dto);
        void Update(int id, UpdatePatientDto dto);
        void Delete(int id);
        IList<GetPatientDto> GetAll();
    }
}
