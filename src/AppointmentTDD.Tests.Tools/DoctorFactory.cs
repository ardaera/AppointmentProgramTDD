using AppointmentTDD.Entities;
using System;

namespace AppointmentTDD.Tests.Tools
{
    public class DoctorFactory
    {
        public Doctor CreateDoctor()
        {
            var doctor = new Doctor
            {
                Field = "ortoped",
                FirstName = "leo",
                LastName = "messi",
                NationalCode ="1236549870"
            };
            return doctor;
        } 
    }
}
