using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Entities
{
    public class Patient: Person
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public HashSet<Appointment> Appointments { get; set; }
    }
}
