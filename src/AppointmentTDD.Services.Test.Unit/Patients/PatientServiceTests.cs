using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Infrastructure.Test;
using AppointmentTDD.Persistence.EF;
using AppointmentTDD.Persistence.EF.Patients;
using AppointmentTDD.Services.Patients;
using AppointmentTDD.Services.Patients.Contracts;
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

        public PatientServiceTests(EFDataContext dataContext,
            UnitOfWork unitOfWork, PatientRepository repository,
            PatientService sut)
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
