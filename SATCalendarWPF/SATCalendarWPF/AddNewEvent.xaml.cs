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
using System.Xml;
using System.IO;

namespace SATCalendarWPF
{
    /// <summary>
    /// Interaction logic for AddNewEvent.xaml
    /// </summary>
    public partial class AddNewEvent : Page
    {
        public AddNewEvent()
        {
            InitializeComponent();
        }

        private void btnDiscardEvent_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to discard this event?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                //Goes back to MainUIWindow.xaml
                this.NavigationService.Navigate(new MainUIWindow());
            }
        }

        private void btnAddNewEvent_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindow.Global.userName == "Kim")
            {
                string appointmentName, appointmentLocation, appointmentDate, startTime, endTime;

                XmlDocument appointments = new XmlDocument();
                string strFileName = @"..\" + "kimAppointments.xml";

                if(!File.Exists(strFileName))
                {
                    appointments.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                        "<appointments></appointments>");
                    appointments.Save(strFileName);
                }

                appointments.Load(strFileName);

                XmlElement nodRoot = appointments.DocumentElement;

                if(string.IsNullOrEmpty(this.txtAppointmentName.Text))
                {
                    MessageBox.Show("You must provide an appointment name.", "Error");
                    return;
                }
                if(string.IsNullOrEmpty(this.txtLocation.Text))
                {
                    MessageBox.Show("You must provide a location.", "Error");
                    return;
                }
                if(string.IsNullOrEmpty(this.txtStartTime.Text))
                {
                    MessageBox.Show("You must provide a starting time.", "Error");
                    return;
                }
                if(string.IsNullOrEmpty(this.txtEndTime.Text))
                {
                    MessageBox.Show("You must provide an end time.", "Error");
                    return;
                }

                appointmentName = txtAppointmentName.Text;
                appointmentLocation = txtLocation.Text;
                appointmentDate = dtpDatePicker.Text;
                startTime = txtStartTime.Text;
                endTime = txtEndTime.Text;

                XmlElement elmAP = appointments.CreateElement("appointment");
                string strNewEvent = "<appointmentName>" + appointmentName + "</appointmentName>" +
                                     "<appointmentDate>" + appointmentDate + "</appointmentDate>" +
                                     "<appointmentStartTime>" + startTime + "</appointmentStartTime>" +
                                     "<appointmentEndTime>" + endTime + "</appointmentEndTime>" +
                                     "<appointmentLocation>" + appointmentLocation + "</appointmentLocation>";
                elmAP.InnerXml = strNewEvent;
                appointments.DocumentElement.AppendChild(elmAP);
                appointments.Save(strFileName);
                MessageBox.Show("Your appointment has been successfully added to the database.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                txtAppointmentName.Clear();
                txtLocation.Clear();
                dtpDatePicker.SelectedDate = null;
                txtStartTime.Clear();
                txtEndTime.Clear();
            }

            if (LoginWindow.Global.userName == "Darren")
            {
                string appointmentName, appointmentLocation, appointmentDate, startTime, endTime;

                XmlDocument appointments = new XmlDocument();
                string strFileName = @"..\" + "darrenAppointments.xml";

                if (!File.Exists(strFileName))
                {
                    appointments.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                        "<appointments></appointments>");
                    appointments.Save(strFileName);
                }

                appointments.Load(strFileName);

                XmlElement nodRoot = appointments.DocumentElement;

                if (string.IsNullOrEmpty(this.txtAppointmentName.Text))
                {
                    MessageBox.Show("You must provide an appointment name.", "Error");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtLocation.Text))
                {
                    MessageBox.Show("You must provide a location.", "Error");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtStartTime.Text))
                {
                    MessageBox.Show("You must provide a starting time.", "Error");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtEndTime.Text))
                {
                    MessageBox.Show("You must provide an end time.", "Error");
                    return;
                }

                appointmentName = txtAppointmentName.Text;
                appointmentLocation = txtLocation.Text;
                appointmentDate = dtpDatePicker.Text;
                startTime = txtStartTime.Text;
                endTime = txtEndTime.Text;


                XmlElement elmAP = appointments.CreateElement("appointment");
                string strNewEvent = "<appointmentName>" + appointmentName + "</appointmentName>" +
                                     "<appointmentDate>" + appointmentDate + "</appointmentDate>" +
                                     "<appointmentStartTime>" + startTime + "</appointmentStartTime>" +
                                     "<appointmentEndTime>" + endTime + "</appointmentEndTime>" +
                                     "<appointmentLocation>" + appointmentLocation + "</appointmentLocation>";
                elmAP.InnerXml = strNewEvent;
                appointments.DocumentElement.AppendChild(elmAP);
                appointments.Save(strFileName);
                MessageBox.Show("Your appointment has been successfully added to the database.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                txtAppointmentName.Clear();
                txtLocation.Clear();
                dtpDatePicker.SelectedDate = null;
                txtStartTime.Clear();
                txtEndTime.Clear();
            }


        }

        private void cbAllDay_Checked(object sender, RoutedEventArgs e)
        {
            txtStartTime.Clear();
            txtEndTime.Clear();
            txtStartTime.IsEnabled = false;
            txtEndTime.IsEnabled = false;
        }

        private void cbAllDay_Unchecked(object sender, RoutedEventArgs e)
        {
            txtStartTime.IsEnabled = true;
            txtEndTime.IsEnabled = true;
        }
    }
}
