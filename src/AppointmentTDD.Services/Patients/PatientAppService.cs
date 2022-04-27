using AppointmentTDD.Entities;
using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Services.Patients.Contracts;
using AppointmentTDD.Services.Patients.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Patients
{
    public class PatientAppService: PatientService
    {
        private readonly PatientRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public PatientAppService(PatientRepository repository, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Add(AddPatientDto dto)
        {
            var patient = new Patient
            {
                NationalCode = dto.NationalCode,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
            };
            _repository.Add(patient);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var patient = _repository.FindId(id);
            if (patient == null)
            {
                throw new PatientForDeleteNotFoundException();
            }
            else
            {
                _repository.Delete(patient);
                _unitOfWork.Commit();
            }
        }

        public IList<GetPatientDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(int id, UpdatePatientDto dto)
        {
            var patient = _repository.FindId(id);
            if (patient==null)
            {
                throw new PatientForUpdateNotFoundException();
            }
            else
            {
                patient.LastName = dto.LastName;
                patient.FirstName = dto.FirstName;
                patient.NationalCode = dto.NationalCode;
                _unitOfWork.Commit();
            }
        }
    }
}
