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
using System.Data;

namespace SATCalendarWPF
{
    /// <summary>
    /// Interaction logic for ViewAllEvents.xaml
    /// </summary>
    public partial class ViewAllEvents : Window
    {
        public ViewAllEvents()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            SetXMLResourcePath();
        }

        private void SetXMLResourcePath()
        {
            if(LoginWindow.Global.userName=="Kim")
            {
                DataSet xmlData = new DataSet();
                xmlData.ReadXml(@"..\" + "kimAppointments.xml", XmlReadMode.Auto);
                dataGrid1.ItemsSource = xmlData.Tables[0].DefaultView;

            }

            if(LoginWindow.Global.userName=="Darren")
            {
                string strFileName = @"..\" + "darrenAppointments.xml";
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(strFileName);
                DataView dataView = new DataView(dataSet.Tables[0]);
                dataGrid1.ItemsSource = dataView;
            }
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
    }
}
