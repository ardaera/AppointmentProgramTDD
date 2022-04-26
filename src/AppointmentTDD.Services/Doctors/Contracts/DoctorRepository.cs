using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Doctors.Contracts
{
    public interface DoctorRepository : Repository
    {
        void Add(Doctor doctor);
        IList<GetPatientDto> GetAll();
        void Delete(Doctor doctor);
        Doctor FindId(int id);
    }
}
