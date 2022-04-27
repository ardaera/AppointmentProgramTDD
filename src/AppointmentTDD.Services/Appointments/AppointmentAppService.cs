using AppointmentTDD.Infrastructure.Application;
using AppointmentTDD.Services.Appointments.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Appointments
{
    public class AppointmentAppService: AppointmentService
    {
        private readonly AppointmentRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public AppointmentAppService(AppointmentRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddAppointmentDto dto)
        {
            throw new NotImplementedException();
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
