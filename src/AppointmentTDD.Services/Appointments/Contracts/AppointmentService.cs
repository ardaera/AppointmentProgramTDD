using AppointmentTDD.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Appointments.Contracts
{
    public interface AppointmentService: Service
    {
        void Add(AddAppointmentDto dto);
        IList<GetAppointmentDto> GetAll();
        void Update(int id, UpdateAppointmentDto dto);
        void Delete(int id);
    }
}
