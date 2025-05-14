using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientAppointments; // for Patient and Appointment classes

namespace DataManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Script to create the database and tables

            // new instance for db connection 
            PatientData db = new PatientData();

            // try, catch for when connecting to the database 
            try
            {
                using (db)
                {
                    // creating Patient objects 
                    Patient p1 = new Patient()
                    {
                        FirstName = "John",
                        Surname = "Smith",
                        DOB = new DateTime(2000, 01, 31),
                        ContactNumber = "086 123 4567"
                    };

                    Patient p2 = new Patient()
                    {
                        FirstName = "Mary",
                        Surname = "Jones",
                        DOB = new DateTime(1980, 06, 15),
                        ContactNumber = "087 323 2585"
                    };

                    Patient p3 = new Patient()
                    {
                        FirstName = "Jim",
                        Surname = "Ryan",
                        DOB = new DateTime(2005, 03, 10),
                        ContactNumber = "086 568 7896"
                    };

                    Console.WriteLine("Created the Patients"); // confirmation message

                    // adding patient objects to the Patients table  in database 
                    db.Patients.Add(p1);
                    db.Patients.Add(p2);
                    db.Patients.Add(p3);

                    // confirmation message 
                    Console.WriteLine("Added Pateints to the database");


                 
                    // save changes made to database 
                    db.SaveChanges();

                    // confirmation messages 
                    Console.WriteLine("Changes have been saved");
                    Console.WriteLine("Press enter to continue");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry an error occured when connecting to the database: " + ex.Message);
            }
        }
    }
}
