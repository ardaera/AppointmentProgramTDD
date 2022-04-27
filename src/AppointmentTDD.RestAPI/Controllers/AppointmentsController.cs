using AppointmentTDD.Services.Appointments.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentTDD.RestAPI.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;
        public AppointmentsController(AppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddAppointmentDto dto)
        {
            _service.Add(dto);
        }


    }
}
