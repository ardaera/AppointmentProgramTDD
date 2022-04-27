using AppointmentTDD.Entities;
using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Infrastructure.Test;
using AppointmentTDD.Persistence.EF;
using AppointmentTDD.Persistence.EF.Patients;
using AppointmentTDD.Services.Patients;
using AppointmentTDD.Services.Patients.Contracts;
using AppointmentTDD.Services.Patients.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppointmentTDD.Services.Test.Unit.Patients
{
    public class PatientServiceTests
    {
        private readonly EFDataContext _dataContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly PatientRepository _repository;
        private readonly PatientService _sut;

        public PatientServiceTests()
        {
            _dataContext = new EFInMemoryDatabase()
                .CreateDataContext<EFDataContext>();
            _unitOfWork = new EFUnitOfWork(_dataContext);
            _repository = new EFPatientRepository(_dataContext);
            _sut = new PatientAppService(_repository, _unitOfWork);
        }


        [Fact]
        public void Add_adds_patient_properly()
        {
            AddPatientDto dto = CreateAddPatientDto();

            _sut.Add(dto);

            _dataContext.Patients.Should()
                .Contain(x => x.LastName == dto.LastName);
            _dataContext.Patients.Should()
                .Contain(x => x.FirstName == dto.FirstName);
            _dataContext.Patients.Should()
                .Contain(x => x.NationalCode == dto.NationalCode);
        }

        [Fact]
        public void GetAll_getalls_patient_properly()
        {
            List<Patient> patients = CreateListOfPatients();
            _dataContext.Manipulate(x => x.Patients.AddRange(patients));

            var expected = _sut.GetAll();

            expected.Should().HaveCount(2);
            expected.Should().Contain(x => x.FirstName == "nima");
            expected.Should().Contain(x => x.FirstName == "nima2");
        }

        [Fact]
        public void Update_updates_patient_properly()
        {
            Patient patient = CreatePatient();
            _dataContext.Manipulate(x => x.Patients.Add(patient));
            UpdatePatientDto dto = CreateUpdatePatientDto();

            _sut.Update(patient.Id, dto);

            var expected = _dataContext.Patients.FirstOrDefault(x => x.Id == patient.Id);
            expected.FirstName.Should().Be(dto.FirstName);
        }

        [Fact]
        public void Update_throw_PatientForUpdateNotFoundException()
        {
            Patient patient = CreatePatient();
            _dataContext.Manipulate(x => x.Patients.Add(patient));
            UpdatePatientDto dto = CreateUpdatePatientDto();

            Action expected = () => _sut.Update(701254, dto);

            expected.Should().ThrowExactly<PatientForUpdateNotFoundException>();
        }

        [Fact]
        public void Delete_deletes_patient_properly()
        {
            Patient patient = CreatePatient();
            _dataContext.Manipulate(x => x.Patients.Add(patient));

            _sut.Delete(patient.Id);

            _dataContext.Patients.Should().NotContain(patient);
        }

        [Fact]
        public void Delete_throw_PatientForDeleteNotFoundException()
        {
            Patient patient = CreatePatient();
            _dataContext.Manipulate(x => x.Patients.Add(patient));

            Action expected = () => _sut.Delete(142501);

            expected.Should().ThrowExactly<PatientForDeleteNotFoundException>();
        }

        private static UpdatePatientDto CreateUpdatePatientDto()
        {
            return new UpdatePatientDto
            {
                FirstName = "aa",
                LastName = "bb",
                NationalCode = "1230007892"
            };
        }

        private static Patient CreatePatient()
        {
            return new Patient
            {
                FirstName = "vb",
                LastName = "bmw",
                NationalCode = "1277779890"
            };
        }

        private static List<Patient> CreateListOfPatients()
        {
            return new List<Patient>
            {
                new Patient
                {
                    FirstName ="nima",
                    LastName ="nimayi",
                    NationalCode="6017521030"
                },
                new Patient
                {
                    FirstName ="nima2",
                    LastName ="nimayi2",
                    NationalCode="6017581030"
                }
            };
        }

        private static AddPatientDto CreateAddPatientDto()
        {
            return new AddPatientDto
            {
                FirstName = "iraj",
                LastName = "ghaderi",
                NationalCode = "6549002658"
            };
        }
    }
}
