﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Services.Appointments.Contracts
{
    public class GetAppointmentDto
    {
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}