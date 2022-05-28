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

namespace Projekt
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        /// <summary>
        /// Connection string.
        /// </summary>
        public string conString = @"Data Source=LAPTOP-CNL6SERI;Initial Catalog=SportsComplex;Integrated Security=True";

        /// <summary>
        /// Initializes register page.
        /// </summary>
        public Register()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {      
            StartingPage p = new StartingPage();
            this.NavigationService.Navigate(p);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text;
            string surname = surnameBox.Text;
            if (!RegisterValidation.NameCheck(ref name, "Imie", out string infoName))
            {
                nameBox.Clear();
                infoBox.Content = infoName;
                return;
            }
            if (!RegisterValidation.NameCheck(ref surname, "Nazwisko", out string infoSurname))
            {
                surnameBox.Clear();
                infoBox.Content = infoSurname;
                return;
            }
            if (!RegisterValidation.EmailCheck(emailBox.Text, out string infoEmail))
            {
                emailBox.Clear();
                infoBox.Content = infoEmail;
                return;
            }
            if (!RegisterValidation.LoginCheck(loginBox.Text, out string infoLogin))
            {
                loginBox.Clear();
                infoBox.Content = infoLogin;
                return;
            }
            if (!RegisterValidation.PasswordCheck(passwordBox.Password, repPasswordBox.Password, out string infoPassword))
            {
                passwordBox.Clear();
                repPasswordBox.Clear();
                infoBox.Content = infoPassword;
                return;
            }
            EmailConfirm p = new EmailConfirm();
            this.NavigationService.Navigate(p);
            EmailSender.SendEmail(emailBox.Text, ConfirmationCode.GenerateNumberAndCount().Result);
            //DatabaseConnector.InsertGuests(name, surname, emailBox.Text, loginBox.Text, passwordBox.Password);
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var v = RegisterValidation.PasswordStrength(passwordBox.Password);
            passwordStrength.Content = v.Item1;
            passwordStrength.Foreground = v.Item2;
        }


    }
}
