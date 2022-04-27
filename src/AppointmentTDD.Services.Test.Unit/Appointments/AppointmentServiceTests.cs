using AppointmentTDD.Entities;
using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Infrastructure.Test;
using AppointmentTDD.Persistence.EF;
using AppointmentTDD.Persistence.EF.Appointments;
using AppointmentTDD.Persistence.EF.Doctors;
using AppointmentTDD.Services.Appointments;
using AppointmentTDD.Services.Appointments.Contracts;
using AppointmentTDD.Services.Doctors.Contracts;
using AppointmentTDD.Tests.Tools;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppointmentTDD.Services.Test.Unit.Appointments
{
    public class AppointmentServiceTests
    {
        private readonly EFDataContext _dataContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly AppointmentRepository _repository;
        private readonly DoctorRepository _doctorRepository;
        private readonly AppointmentService _sut;

        public AppointmentServiceTests()
        {
            _dataContext = new EFInMemoryDatabase()
                .CreateDataContext<EFDataContext>();
            _unitOfWork = new EFUnitOfWork(_dataContext);
            _repository = new EFAppointmentRepository(_dataContext);
            _doctorRepository = new EFDoctorRepository(_dataContext);
            _sut = new AppointmentAppService
                (_repository, _unitOfWork, _doctorRepository);
        }

        [Fact]
        public void Add_adds_appointment_properly()
        {
            DoctorFactory doctorFactory = new DoctorFactory();
            Doctor doctor = doctorFactory.CreateDoctor();
            _dataContext.Manipulate(x => x.Doctors.Add(doctor));
            PatientFactory patientFactory = new PatientFactory();
            Patient patient = patientFactory.CreatePatient();
            _dataContext.Manipulate(x => x.Patients.Add(patient));
            AddAppointmentDto dto = new AddAppointmentDto
            {
                Date = DateTime.Now.Date,
                DoctorId = doctor.Id,
                PatientId = patient.Id,
            };

            _sut.Add(dto);

            var expected = _dataContext.Appointments.FirstOrDefault();
            expected.Date.Should().Be(dto.Date);
            expected.DoctorId.Should().Be(dto.DoctorId);
            expected.PatientId.Should().Be(dto.PatientId);
        }

        [Fact]
        public void Add_DoctorAppointmentsAreFullException()
        {
            DoctorFactory doctorFactory = new DoctorFactory();
            Doctor doctor = doctorFactory.CreateDoctor();
            _dataContext.Manipulate(x => x.Doctors.Add(doctor));
            List<Patient> patients = new List<Patient>
            {
                new Patient
                {
                    FirstName = "a",
                    LastName = "b",
                    NationalCode ="0258741369"
                },new Patient
                {
                    FirstName = "a2",
                    LastName = "b2",
                    NationalCode ="0258742369"
                },new Patient
                {
                    FirstName = "a3",
                    LastName = "b3",
                    NationalCode ="0258341369"
                },new Patient
                {
                    FirstName = "a4",
                    LastName = "b4",
                    NationalCode ="0258741469"
                },new Patient
                {
                    FirstName = "a5",
                    LastName = "b5",
                    NationalCode ="0255741369"
                },
            };
            _dataContext.Manipulate(x => x.Patients.AddRange(patients));
            List<Appointment> appointments = new List<Appointment>
            {
                new Appointment
                {
                    Date = DateTime.Now.Date,
                    DoctorId=doctor.Id,
                    PatientId=patients[0].Id,
                },
                new Appointment
                {
                    Date = DateTime.Now.Date,
                    DoctorId=doctor.Id,
                    PatientId=patients[1].Id,
                },new Appointment
                {
                    Date = DateTime.Now.Date,
                    DoctorId=doctor.Id,
                    PatientId=patients[2].Id,
                },new Appointment
                {
                    Date = DateTime.Now.Date,
                    DoctorId=doctor.Id,
                    PatientId=patients[3].Id,
                },new Appointment
                {
                    Date = DateTime.Now.Date,
                    DoctorId=doctor.Id,
                    PatientId=patients[4].Id,
                },
            };
            _dataContext.Manipulate(x => x.AddRange(appointments));
            PatientFactory patientFactory = new PatientFactory();
            Patient patient = patientFactory.CreatePatient();
            _dataContext.Manipulate(x => x.Patients.Add(patient));
            AddAppointmentDto dto = new AddAppointmentDto
            {
                Date = DateTime.Now.Date,
                DoctorId = doctor.Id,
                PatientId = patient.Id,
            };

            Action expected = () => _sut.Add(dto);

            expected.Should().Throw<DoctorAppointmentsAreFullException>();
        }




    }












}
