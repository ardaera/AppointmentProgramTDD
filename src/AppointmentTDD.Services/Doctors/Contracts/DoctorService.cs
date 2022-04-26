using AppointmentTDD.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Doctors.Contracts
{
    public interface DoctorService : Service
    {
        void Add(AddPatientDto dto);
        IList<GetPatientDto> GetAll();
        void Update(int id, UpdatePatientDto dto);
        void Delete(int id);
    }
}
