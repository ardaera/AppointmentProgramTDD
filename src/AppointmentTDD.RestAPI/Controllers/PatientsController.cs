using AppointmentTDD.Services.Patients.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppointmentTDD.RestAPI.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _service;
        public PatientsController(PatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddPatientDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public IList<GetPatientDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPut]
        public void Update(int id, UpdatePatientDto dto)
        {
            _service.Update(id, dto);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
