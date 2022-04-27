using AppointmentTDD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Tests.Tools
{
    public class PatientFactory
    {
        public Patient CreatePatient()
        {
            var patient = new Patient
            {
                NationalCode = "3692581470",
                LastName = "ronaldo",
                FirstName = "michel"
            };
            return patient;
        }
    }
}
