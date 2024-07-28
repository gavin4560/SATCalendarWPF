//MainUIWindow.xaml.cs
//Created on 6/6/2020
//Written by Gavin
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace SATCalendarWPF
{
    /// <summary>
    /// Interaction logic for MainUIWindow.xaml
    /// </summary>
    /// 


    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class appointments
    {

        private appointmentsAppointment[] appointmentField;

        [System.Xml.Serialization.XmlElementAttribute("appointment")]
        public appointmentsAppointment[] appointment
        {
            get
            {
                return this.appointmentField;
            }
            set
            {
                this.appointmentField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class appointmentsAppointment
    {

        private string appointmentNameField;

        private string appointmentDateField;

        private string appointmentStartTimeField;

        private string appointmentEndTimeField;

        private string appointmentLocationField;

        public string appointmentName
        {
            get
            {
                return this.appointmentNameField;
            }
            set
            {
                this.appointmentNameField = value;
            }
        }

        public string appointmentDate
        {
            get
            {
                return this.appointmentDateField;
            }
            set
            {
                this.appointmentDateField = value;
            }
        }

        public string appointmentStartTime
        {
            get
            {
                return this.appointmentStartTimeField;
            }
            set
            {
                this.appointmentStartTimeField = value;
            }
        }

        public string appointmentEndTime
        {
            get
            {
                return this.appointmentEndTimeField;
            }
            set
            {
                this.appointmentEndTimeField = value;
            }
        }

        public string appointmentLocation
        {
            get
            {
                return this.appointmentLocationField;
            }
            set
            {
                this.appointmentLocationField = value;
            }
        }
    }




    //Generated code for Family Roster XML (Paste Special)
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class rosters
    {

        private rostersRoster[] rosterField;

        [System.Xml.Serialization.XmlElementAttribute("roster")]
        public rostersRoster[] roster
        {
            get
            {
                return this.rosterField;
            }
            set
            {
                this.rosterField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rostersRoster
    {

        private string childNameField;

        private string activityField;

        public string childName
        {
            get
            {
                return this.childNameField;
            }
            set
            {
                this.childNameField = value;
            }
        }

        public string activity
        {
            get
            {
                return this.activityField;
            }
            set
            {
                this.activityField = value;
            }
        }
    }




    public partial class MainUIWindow : Page
    {
        public MainUIWindow()
        {
            InitializeComponent();
        }

        private void MainUIWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Based on what the userName variable in LoginWindow.xaml.cs is set to, it displays it here.
            WelcomeLabel.Content = "Welcome, " + LoginWindow.Global.userName;

            //Help from C# Discord
            //Deserialises XML file and then sets labels to values from XML
            var z = new XmlSerializer(typeof(rosters));
            var a = new StreamReader(@"..\" + "familyRoster.xml");
            var rosterItems = (rosters)z.Deserialize(a);
            childName1.Content = rosterItems.roster[0].childName;
            activity1.Content = rosterItems.roster[0].activity;
            childName2.Content = rosterItems.roster[1].childName;
            activity2.Content = rosterItems.roster[1].activity;
            childName3.Content = rosterItems.roster[2].childName;
            activity3.Content = rosterItems.roster[2].activity;
            
            if (LoginWindow.Global.userName == "Kim")
            {
                //Deserialises XML file and then sets labels to values from XML
                var s = new XmlSerializer(typeof(appointments));
                var r = new StreamReader(@"..\" + "kimAppointments.xml");
                var items = (appointments)s.Deserialize(r);

                appointment1.Content = items.appointment[0].appointmentName;
                appointmentDetails1.Content = items.appointment[0].appointmentDate;
                appointment2.Content = items.appointment[1].appointmentName;
                appointmentDetails2.Content = items.appointment[1].appointmentDate;
                appointment3.Content = items.appointment[2].appointmentName;
                appointmentDetails3.Content = items.appointment[2].appointmentDate;
            }

            if (LoginWindow.Global.userName == "Darren")
            {
                //Deserialises XML file and then sets labels to values from XML
                var s = new XmlSerializer(typeof(appointments));
                var r = new StreamReader(@"..\" + "darrenAppointments.xml");
                var items = (appointments)s.Deserialize(r);

                appointment1.Content = items.appointment[0].appointmentName;
                appointmentDetails1.Content = items.appointment[0].appointmentDate;
                appointment2.Content = items.appointment[1].appointmentName;
                appointmentDetails2.Content = items.appointment[1].appointmentDate;
                appointment3.Content = items.appointment[2].appointmentName;
                appointmentDetails3.Content = items.appointment[2].appointmentDate;
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                //Goes back to LoginWindow.xaml
                this.NavigationService.Navigate(new LoginWindow());
            }
        }

        private void btnAddNewEvent_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddNewEvent());
        }

        private void btnViewAllEvents_Click(object sender, RoutedEventArgs e)
        {
            ViewAllEvents objViewAllEvents = new ViewAllEvents();
            objViewAllEvents.Show();
        }

        private void btnEditRoster_Click(object sender, RoutedEventArgs e)
        {
            EditRoster objEditRoster = new EditRoster();
            objEditRoster.Show();
        }

        private void btnViewAllRoster_Click(object sender, RoutedEventArgs e)
        {
            ViewAllRoster objViewAllRoster = new ViewAllRoster();
            objViewAllRoster.Show();
        }

        private void btnEditEvent1_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindow.Global.userName == "Kim")
            {
                //Deserialises XML file and then sets labels to values from XML
                var s = new XmlSerializer(typeof(appointments));
                var r = new StreamReader(@"..\" + "kimAppointments.xml");
                var items = (appointments)s.Deserialize(r);

                EditEvent objEditEvent = new EditEvent();
                objEditEvent.txtAppointmentName.Text = items.appointment[0].appointmentName;
                objEditEvent.dtpDatePicker.Text = items.appointment[0].appointmentDate;
                objEditEvent.txtStartTime.Text = items.appointment[0].appointmentStartTime;
                objEditEvent.txtEndTime.Text = items.appointment[0].appointmentEndTime;
                objEditEvent.txtLocation.Text = items.appointment[0].appointmentLocation;
                objEditEvent.Show();
            }

            if (LoginWindow.Global.userName == "Darren")
            {
                //Deserialises XML file and then sets labels to values from XML
                var s = new XmlSerializer(typeof(appointments));
                var r = new StreamReader(@"..\" + "darrenAppointments.xml");
                var items = (appointments)s.Deserialize(r);

                EditEvent objEditEvent = new EditEvent();
                objEditEvent.txtAppointmentName.Text = items.appointment[0].appointmentName;
                objEditEvent.dtpDatePicker.Text = items.appointment[0].appointmentDate;
                objEditEvent.txtStartTime.Text = items.appointment[0].appointmentStartTime;
                objEditEvent.txtEndTime.Text = items.appointment[0].appointmentEndTime;
                objEditEvent.txtLocation.Text = items.appointment[0].appointmentLocation;
                objEditEvent.Show();
            }
        }

        private void btnEditEvent2_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindow.Global.userName == "Kim")
            {
                //Deserialises XML file and then sets labels to values from XML
                var s = new XmlSerializer(typeof(appointments));
                var r = new StreamReader(@"..\" + "kimAppointments.xml");
                var items = (appointments)s.Deserialize(r);

                EditEvent objEditEvent = new EditEvent();
                objEditEvent.txtAppointmentName.Text = items.appointment[1].appointmentName;
                objEditEvent.dtpDatePicker.Text = items.appointment[1].appointmentDate;
                objEditEvent.txtStartTime.Text = items.appointment[1].appointmentStartTime;
                objEditEvent.txtEndTime.Text = items.appointment[1].appointmentEndTime;
                objEditEvent.txtLocation.Text = items.appointment[1].appointmentLocation;
                objEditEvent.Show();
            }

            if (LoginWindow.Global.userName == "Darren")
            {
                //Deserialises XML file and then sets labels to values from XML
                var s = new XmlSerializer(typeof(appointments));
                var r = new StreamReader(@"..\" + "darrenAppointments.xml");
                var items = (appointments)s.Deserialize(r);

                EditEvent objEditEvent = new EditEvent();
                objEditEvent.txtAppointmentName.Text = items.appointment[1].appointmentName;
                objEditEvent.dtpDatePicker.Text = items.appointment[1].appointmentDate;
                objEditEvent.txtStartTime.Text = items.appointment[1].appointmentStartTime;
                objEditEvent.txtEndTime.Text = items.appointment[1].appointmentEndTime;
                objEditEvent.txtLocation.Text = items.appointment[1].appointmentLocation;
                objEditEvent.Show();
            }
        }

        private void btnEditEvent3_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindow.Global.userName == "Kim")
            {
                //Deserialises XML file and then sets labels to values from XML
                var s = new XmlSerializer(typeof(appointments));
                var r = new StreamReader(@"..\" + "kimAppointments.xml");
                var items = (appointments)s.Deserialize(r);

                EditEvent objEditEvent = new EditEvent();
                objEditEvent.txtAppointmentName.Text = items.appointment[2].appointmentName;
                objEditEvent.dtpDatePicker.Text = items.appointment[2].appointmentDate;
                objEditEvent.txtStartTime.Text = items.appointment[2].appointmentStartTime;
                objEditEvent.txtEndTime.Text = items.appointment[2].appointmentEndTime;
                objEditEvent.txtLocation.Text = items.appointment[2].appointmentLocation;
                objEditEvent.Show();
            }

            if (LoginWindow.Global.userName == "Darren")
            {
                //Deserialises XML file and then sets labels to values from XML
                var s = new XmlSerializer(typeof(appointments));
                var r = new StreamReader(@"..\" + "darrenAppointments.xml");
                var items = (appointments)s.Deserialize(r);

                EditEvent objEditEvent = new EditEvent();
                objEditEvent.txtAppointmentName.Text = items.appointment[2].appointmentName;
                objEditEvent.dtpDatePicker.Text = items.appointment[2].appointmentDate;
                objEditEvent.txtStartTime.Text = items.appointment[2].appointmentStartTime;
                objEditEvent.txtEndTime.Text = items.appointment[2].appointmentEndTime;
                objEditEvent.txtLocation.Text = items.appointment[2].appointmentLocation;
                objEditEvent.Show();
            }
        }
    }
}
