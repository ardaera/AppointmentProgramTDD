using AppointmentTDD.Entities;
using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Services.Doctors.Contracts;
using AppointmentTDD.Services.Doctors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Doctors
{
    public class DoctorAppService : DoctorService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly DoctorRepository _repository;

        public DoctorAppService(UnitOfWork unitOfWork, DoctorRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Add(AddPatientDto dto)
        {
            var doctor = new Doctor
            {
                Field = dto.Field,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                NationalCode = dto.NationalCode,
            };
            _repository.Add(doctor);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
           var doctor= _repository.FindId(id);
            if (doctor==null)
            {
                throw new PatientForDeleteNotFoundException();
            }
            else
            {
                _repository.Delete(doctor);
                _unitOfWork.Commit();
            }
        }

        public IList<GetPatientDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(int id, UpdatePatientDto dto)
        {
            var doctor = _repository.FindId(id);
            if (doctor==null)
            {
                throw new PatientForUpdateNotFoundException();
            }
            else
            {
                doctor.FirstName = dto.FirstName;
                doctor.LastName = dto.LastName;
                doctor.NationalCode = dto.NationalCode;
                doctor.Field= dto.Field;
                _unitOfWork.Commit();
            }
        }
    }
}
