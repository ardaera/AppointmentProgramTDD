using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Infrastructure.Test;
using AppointmentTDD.Persistence.EF;
using AppointmentTDD.Persistence.EF.Doctors;
using AppointmentTDD.Services.Doctors;
using AppointmentTDD.Services.Doctors.Contracts;
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
            var dto = new AddDoctorDto
            {
                Field = "ghalb",
                FirstName = "firstname",
                LastName = "lastname",
                NationalCode = "1234567890"
            };

            _sut.Add(dto);

            _dataContext.Doctors.Should().Contain(x => x.FirstName == dto.FirstName);
            _dataContext.Doctors.Should().Contain(x => x.LastName == dto.LastName);
        }






    }

    


}
