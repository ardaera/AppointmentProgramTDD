using AppointmentTDD.Entities;
using AppointmentTDD.Services.Appointments.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Persistence.EF.Appointments
{
    public class EFAppointmentRepository : AppointmentRepository
    {
        private readonly EFDataContext _dataContext;

        public EFAppointmentRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Appointment appointment)
        {
            _dataContext.Appointments.Add(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _dataContext.Appointments.Remove(appointment);
        }

        public Appointment FindId(int id)
        {
            return _dataContext.Appointments.Find(id);
        }

        public IList<GetAppointmentDto> GetAll()
        {
            return _dataContext.Appointments.Select(x => new GetAppointmentDto
            {
                Date = x.Date,
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
            }).ToList();
        }
    }
}
