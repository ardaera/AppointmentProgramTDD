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
        void Add(AddDoctorDto dto);
        IList<GetDoctorDto> GetAll();
        void Update(int id, UpdateDoctorDto dto);
        void Delete(int id);
    }
}
