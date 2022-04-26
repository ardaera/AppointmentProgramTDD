﻿using AppointmentTDD.Services.Doctors.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppointmentTDD.RestAPI.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _service;
        public DoctorsController(DoctorService service)
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

        [HttpPut("{id}")]
        public void Update(int id, UpdatePatientDto dto)
        {
            _service.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

    }
}
