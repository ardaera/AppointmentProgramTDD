using AppointmentTDD.Entities;
using System.Collections.Generic;

namespace AppointmentTDD.Services.Patients.Contracts
{
    public class UpdatePatientDto
    {
        public int Id { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HashSet<Appointment> Appointments { get; set; }
    }
}