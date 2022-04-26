using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Entities
{
    public class Doctor : Person
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }
        public string Field { get; set; }
        public HashSet<Appointment> Appointments { get; set; }
    }
}
