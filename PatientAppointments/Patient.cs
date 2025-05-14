using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointments
{
    public class Patient
    {
        // properties 
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNumber { get; set; }

        // foreign key relationship (one to many)
        public virtual List<Appointment> Appointments { get; set; } // virtual keyword for lazy loading 

        // override the ToString method
        public override string ToString()
        {
            return $"{Surname}, {FirstName} - {ContactNumber}";  // display data 
        }
    }
}
