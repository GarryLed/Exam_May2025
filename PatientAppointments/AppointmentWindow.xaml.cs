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
using System.Windows.Shapes;

namespace PatientAppointments
{
    /// <summary>
    /// Interaction logic for AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        // create a new instance of the PatientData class
        PatientData db = new PatientData(); // create a new instance of the PatientData class
        public AppointmentWindow()
        {
            InitializeComponent();
        }

        // loaded constructor 
        public AppointmentWindow(DateTime AppointmentTime, string AppointmentNotes) : this() 
        {
            _appointmentTime = AppointmentTime; // set the appointment time
            _appointmentNotes = AppointmentNotes; // set the appointment notes

        }

    }
}
