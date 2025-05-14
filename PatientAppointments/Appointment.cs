using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointments
{
    public class Appointment
    {
        // properties 
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string AppointmentNotes { get; set; }

        // foreign key for the Patient class (a patient can have many appointments) 
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        // override the ToString method
        public override string ToString()
        {
            return $"{AppointmentTime} - {AppointmentId} patients"; // temp code 
        }
    }
}
