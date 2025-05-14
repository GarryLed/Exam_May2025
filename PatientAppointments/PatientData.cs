using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // for Entity Framework

namespace PatientAppointments
{
    public class PatientData : DbContext
    {
        // constructor 
        public PatientData() : base("OODExam_GarryLedwith") { }// name of the connection string in App.config
        
        
        // DbSet properties for the Patient and Appointment classes
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
   
}
