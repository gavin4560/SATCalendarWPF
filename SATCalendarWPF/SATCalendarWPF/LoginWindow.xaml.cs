//LoginWindow.xaml.cs
//Created on 6/6/2020
//Written by Gavin Jessel
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
using System.IO;
using System.Xml;

namespace SATCalendarWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Page
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        public class Global //Define global variables
        {
            public static string userName;
        }

        public void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument users = new XmlDocument();
            string strFileName = @"..\" + "users.xml";

            //Existence checks for username and password boxes.
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                MessageBox.Show("You did not enter a username. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (string.IsNullOrEmpty(PasswordBox.Password.ToString()))
            {
                MessageBox.Show("You did not enter a password. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (File.Exists(strFileName))
            {
                users.Load(strFileName);
                XmlElement xeUsers = users.DocumentElement;
                XmlNodeList xnlUsers = xeUsers.GetElementsByTagName("userName");


                foreach (XmlNode xnUsers in xnlUsers)
                {
                    if (xnUsers.InnerText == UsernameTextBox.Text)
                    {
                        if (xnUsers.NextSibling.InnerText == PasswordBox.Password.ToString())
                        {
                            if (UsernameTextBox.Text == "Kim")
                            {
                                //Sets userName to be used in MainUIWindow.xaml, then moves to MainWindow.xaml
                                Global.userName = "Kim";
                                this.NavigationService.Navigate(new MainUIWindow());
                            }
                            if (UsernameTextBox.Text == "Darren")
                            {
                                //Sets userName to be used in MainUIWindow.xaml, then moves to MainWindow.xaml
                                Global.userName = "Darren";
                                this.NavigationService.Navigate(new MainUIWindow());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your password is incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            PasswordBox.Clear();
                        }
                    }
                }

            }
        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                //When Enter key is pressed, it acts as if the login button was pressed
                btnLogIn_Click(this, new RoutedEventArgs());
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                //When Enter key is pressed, it acts as if the login button was pressed
                btnLogIn_Click(this, new RoutedEventArgs());
            }
        }
    }
}
