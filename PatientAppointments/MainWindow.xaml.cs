using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PatientAppointments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PatientData db = new PatientData(); // create a new instance of the PatientData class 
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Loaded event of the Window control. This event is triggered when the window is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // display the initial patients when the window loads
            DisplayPatients();

        }

       
        /// <summary>
        /// Displays the initial patients in the list box.
        /// </summary>

        private void DisplayPatients()
        {
            try // try, catch for handling exceptions
            {
                var patients = from p in db.Patients // LINQ query to get all patients
                               where p.FirstName != null
                               orderby p.Surname // order by surname
                               select p;


                lbxPatients.ItemsSource = patients.ToList(); // set the list box source to the patients list

            }
            catch (Exception ex) // catch any exceptions 
            {
                MessageBox.Show("Failed to load movies: " + ex.Message);
            }
        }
        /// <summary>
        /// Handles the Click event of the btnAddPatient control. 
        /// This event is triggered when the "Add Patient" button is clicked
        /// create a new patient object and add it to the database.
        /// display the updated list of patients in the list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            try // try, catch for handling exceptions
            {
                // create a new patient object 
                Patient newPatient = new Patient()
                {
                    FirstName = tbxFirstName.Text, // get the first name from the text box and assign it to FirstName property
                    Surname = tbxSurname.Text, // get the surname from the text box and assign it to Surname property
                    DOB = DateTime.Parse(dpDOB.Text), // get the date of birth from the date picker and assign it to DOB property
                    ContactNumber = tbxPhoneNumber.Text // get the contact number from the text box and assign it to ContactNumber property
                };
                db.Patients.Add(newPatient); // add the new patient to the Patients table in the database
                db.SaveChanges(); // save the changes to the database
                DisplayPatients(); // display the updated list of patients
            }
            catch (Exception ex) // catch any exceptions 
            {
                MessageBox.Show("Failed to add patient: " + ex.Message);
            }

        }

        /// <summary>
        /// Handles the Click event of the btnDeletePatient control.
        /// opens a second window to make appointment for the selected patient.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateNewAppointment_Click(object sender, RoutedEventArgs e)
        {

            if (lbxPatients.SelectedItem is Patient selectedPatient) // use selectedPatient as variable 
            {
                
                // create a new appointment window 
                AppointmentWindow appointmentWindow = new AppointmentWindow(selectedPatient); 
                appointmentWindow.Owner = this;
                // display the appointment window
                appointmentWindow.ShowDialog();
            }
          

        }

        /// <summary>
        /// Handles the SelectionChanged event of the lbxPatients control
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // check if a patient is selected
           
            if (lbxPatients.SelectedItem is Patient selectedPatient) // use selectedPatient as variable 
            {
                // set each text box to the selected patient's properties
                tbxFirstName.Text = selectedPatient.FirstName;
                tbxSurname.Text = selectedPatient.Surname;
                dpDOB.Text = selectedPatient.DOB.ToString();
                tbxPhoneNumber.Text = selectedPatient.ContactNumber;
            }

        }

        /// <summary>
        /// Handles the SelectionChanged event of the lbxAppointments control
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
