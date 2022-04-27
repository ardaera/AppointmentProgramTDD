using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Infrastructure.Test;
using AppointmentTDD.Persistence.EF;
using AppointmentTDD.Persistence.EF.Patients;
using AppointmentTDD.Services.Patients;
using AppointmentTDD.Services.Patients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _sut = new PatientAppService(_unitOfWork,_repository);
        }




    }
}
