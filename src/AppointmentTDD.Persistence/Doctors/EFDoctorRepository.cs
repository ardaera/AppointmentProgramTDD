using AppointmentTDD.Entities;
using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Services.Appointments.Contracts;
using AppointmentTDD.Services.Doctors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Persistence.EF.Doctors
{
    public class EFDoctorRepository : DoctorRepository
    {
        private readonly EFDataContext _dataContext;
        public EFDoctorRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Doctor doctor)
        {
            _dataContext.Doctors.Add(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _dataContext.Doctors.Remove(doctor);
        }

        public Doctor FindId(int id)
        {
            return _dataContext.Doctors.Find(id);
        }

        public IList<GetDoctorDto> GetAll()
        {
            return _dataContext.Doctors.Select(x => new GetDoctorDto
            {
                Id= x.Id,
                Field = x.Field,
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
                Appointments = x.Appointments
            }).ToList();
        }
    }
}
