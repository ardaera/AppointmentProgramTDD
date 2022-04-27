using AppointmentTDD.Entities;
using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Infrastructure.Test;
using AppointmentTDD.Persistence.EF;
using AppointmentTDD.Persistence.EF.Doctors;
using AppointmentTDD.Services.Doctors;
using AppointmentTDD.Services.Doctors.Contracts;
using AppointmentTDD.Services.Doctors.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppointmentTDD.Services.Test.Unit.Doctors
{
    public class DoctorServiceTests
    {
        private readonly EFDataContext _dataContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly DoctorRepository _repository;
        private readonly DoctorService _sut;

        public DoctorServiceTests()
        {
            _dataContext = new EFInMemoryDatabase()
                .CreateDataContext<EFDataContext>();

            _unitOfWork = new EFUnitOfWork(_dataContext);
            _repository = new EFDoctorRepository(_dataContext);
            _sut = new DoctorAppService(_unitOfWork, _repository);
        }

        [Fact]
        public void Add_adds_doctor_properly()
        {
            AddDoctorDto dto = CreateDoctorDto();

            _sut.Add(dto);

            _dataContext.Doctors.Should().Contain(x => x.FirstName == dto.FirstName);
            _dataContext.Doctors.Should().Contain(x => x.LastName == dto.LastName);
        }

        [Fact]
        public void GetAll_getall_doctors_properly()
        {
            List<Doctor> doctors = CreateListOfDoctors();
            _dataContext.Manipulate(x => x.Doctors.AddRange(doctors));

            var expected = _sut.GetAll();

            expected.Should().HaveCount(2);
            expected.Should().Contain(x => x.FirstName == "kamran");
            expected.Should().Contain(x => x.FirstName == "kamran2");
        }

        [Fact]
        public void Update_updates_doctor_properly()
        {
            Doctor doctor = CreateDoctor();
            _dataContext.Manipulate(x => x.Doctors.Add(doctor));
            UpdateDoctorDto dto = CreateUpdateDoctorDto();

            _sut.Update(doctor.Id, dto);

            var expected = _dataContext.Doctors.FirstOrDefault(x => x.Id == doctor.Id);
            expected.FirstName.Should().Be(dto.FirstName);
        }

        [Fact]
        public void Update_throw_DoctorForUpdateNotFoundException()
        {
            Doctor doctor = CreateDoctor();
            _dataContext.Manipulate(x => x.Doctors.Add(doctor));
            UpdateDoctorDto dto = CreateUpdateDoctorDto();

            Action expected = () => _sut.Update(312102, dto);

            expected.Should().ThrowExactly<DoctorForUpdateNotFoundException>();
        }

        [Fact]
        public void Delete_deletes_doctor_properly()
        {
            Doctor doctor = CreateDoctor();
            _dataContext.Manipulate(x => x.Doctors.Add(doctor));

            _sut.Delete(doctor.Id);

            _dataContext.Doctors.Should().NotContain(doctor);
        }

        [Fact]
        public void Delete_throw_DoctorForDeleteNotFoundException()
        {
            Doctor doctor = CreateDoctor();
            _dataContext.Manipulate(x => x.Doctors.Add(doctor));

            Action expected = () => _sut.Delete(180515);

            expected.Should().ThrowExactly<DoctorForDeleteNotFoundException>();
        }

        private static UpdateDoctorDto CreateUpdateDoctorDto()
        {
            return new UpdateDoctorDto
            {
                Field = "maghz",
                FirstName = "kamran2",
                LastName = "hoomani2",
                NationalCode = "1234567892"
            };
        }

        private static Doctor CreateDoctor()
        {
            return new Doctor
            {
                Field = "ghalb",
                FirstName = "kamran",
                LastName = "hoomani",
                NationalCode = "1234567890"
            };
        }

        private static AddDoctorDto CreateDoctorDto()
        {
            return new AddDoctorDto
            {
                Field = "ghalb",
                FirstName = "firstname",
                LastName = "lastname",
                NationalCode = "1234567890"
            };
        }

        private static List<Doctor> CreateListOfDoctors()
        {
            return new List<Doctor>
            {
                new Doctor
                {
                    Field="ghalb",
                    FirstName ="kamran",
                    LastName ="hoomani",
                    NationalCode="1234567890"
                },
                new Doctor
                {
                    Field="maghz",
                    FirstName ="kamran2",
                    LastName ="hoomani2",
                    NationalCode="1234567892"
                }
            };
        }
    }
}
