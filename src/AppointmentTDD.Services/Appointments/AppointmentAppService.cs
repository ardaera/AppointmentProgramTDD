using AppointmentTDD.Entities;
using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Services.Appointments.Contracts;
using AppointmentTDD.Services.Doctors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Appointments
{
    public class AppointmentAppService : AppointmentService
    {
        private readonly AppointmentRepository _repository;
        private readonly DoctorRepository _doctorRepository;
        private readonly UnitOfWork _unitOfWork;

        public AppointmentAppService(AppointmentRepository repository,
            UnitOfWork unitOfWork, DoctorRepository doctorRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _doctorRepository = doctorRepository;
        }

        public void Add(AddAppointmentDto dto)
        {
            Appointment appointment = new Appointment
            {
                Date = dto.Date.Date,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
            };
            var doctor = _doctorRepository.GetAll()
                .FirstOrDefault(x => x.Id == dto.DoctorId);
            if (doctor.Appointments.Count < 5)
            {
                _repository.Add(appointment);
                _unitOfWork.Commit();
            }
            else
            {
                throw new DoctorAppointmentsAreFullException();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<GetAppointmentDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UpdateAppointmentDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
