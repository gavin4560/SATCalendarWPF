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
using System.Xml;
using System.IO;

namespace SATCalendarWPF
{
    /// <summary>
    /// Interaction logic for EditEvent.xaml
    /// </summary>
    public partial class EditEvent : Window
    {
        public EditEvent()
        {
            InitializeComponent();
            CenterWindowOnScreen();
        }
        private void CenterWindowOnScreen() //Centers the dialog box, code was used from https://stackoverflow.com/questions/4019831/how-do-you-center-your-main-window-in-wpf
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void btnEditEvent_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindow.Global.userName == "Kim")
            {

                XmlDocument appointments = new XmlDocument();
                string strFileName = @"..\" + "kimAppointments.xml";

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
                XmlNodeList xnAppName = appointments.DocumentElement.GetElementsByTagName("appointments");
                XmlNode xnAllApps = appointments.CreateElement("appointment");

                XmlNode appName = appointments.CreateElement("appointmentName");
                appName.InnerText = txtAppointmentName.Text;
                xnAllApps.AppendChild(appName);

                appointments.Save(strFileName);
                MessageBox.Show("Your appointment has been successfully edited.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this event?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                XmlDocument appointments = new XmlDocument();
                string strFileName = @"..\" + "kimAppointments.xml";

                appointments.Load(strFileName);
                XmlNodeList appNames = appointments.DocumentElement.GetElementsByTagName("appointmentName");

                foreach (XmlNode appName in appNames)
                {
                    if (appName.InnerText == txtAppointmentName.Text)
                    {
                        appointments.DocumentElement.RemoveChild(appName.ParentNode);
                        break;
                    }
                }
            }
        }

        private void chkAllDay_Checked(object sender, RoutedEventArgs e)
        {
            txtStartTime.Clear();
            txtEndTime.Clear();
            txtStartTime.IsEnabled = false;
            txtEndTime.IsEnabled = false;
        }

        private void chkAllDay_Unchecked(object sender, RoutedEventArgs e)
        {
            txtStartTime.IsEnabled = true;
            txtEndTime.IsEnabled = true;
        }
    }
}
