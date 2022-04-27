using AppointmentTDD.Entities;
using AppointmentTDD.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Appointments.Contracts
{
    public interface AppointmentRepository: Repository
    {
        void Add(Appointment appointment);
        Appointment FindId(int id);
        void Delete(Appointment appointment);
        IList<GetAppointmentDto> GetAll();
    }
}
