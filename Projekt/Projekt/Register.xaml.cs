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
            if (!NameCheck(ref name, "Imie", out string infoName))
            {
                nameBox.Clear();
                infoBox.Content = infoName;
                return;
            }
            if (!NameCheck(ref surname, "Nazwisko", out string infoSurname))
            {
                surnameBox.Clear();
                infoBox.Content = infoSurname;
                return;
            }
            if (!EmailCheck(emailBox.Text, out string infoEmail))
            {
                emailBox.Clear();
                infoBox.Content = infoEmail;
                return;
            }
            if (!LoginCheck(loginBox.Text, out string infoLogin))
            {
                loginBox.Clear();
                infoBox.Content = infoLogin;
                return;
            }
            if (!PasswordCheck(passwordBox.Password, repPasswordBox.Password, out string infoPassword))
            {
                passwordBox.Clear();
                repPasswordBox.Clear();
                infoBox.Content = infoPassword;
                return;
            }
            EmailConfirm p = new EmailConfirm();
            this.NavigationService.Navigate(p);
            EmailSender.SendEmail(emailBox.Text, 5);
            //DatabaseConnector.InsertGuests(name, surname, emailBox.Text, loginBox.Text, passwordBox.Password);
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            switch (PasswordStrength(passwordBox.Password))
            {
                case "empty":
                    passwordStrength.Content = "";
                    break;
                case "weak":
                    passwordStrength.Content = "Słabe hasło";
                    passwordStrength.Foreground = Brushes.Red;
                    break;
                case "medium":
                    passwordStrength.Content = "Średnie hasło";
                    passwordStrength.Foreground = Brushes.GreenYellow;
                    break;
                case "strong":
                    passwordStrength.Content = "Silne hasło";
                    passwordStrength.Foreground = Brushes.Green;
                    break;
            }

        }

        private string PasswordStrength(string input)
        {
            if (input == string.Empty)
                return "empty";
            else if (input.Length < 8)
                return "weak";
            else if (input.Any(Char.IsUpper) && input.Any(Char.IsDigit) && input.Any(c => !Char.IsLetterOrDigit(c)))
                return "strong";
            else if (input.Any(Char.IsUpper) && input.Any(Char.IsDigit))
                return "medium";
            else
                return "weak";
        }

        private bool NameCheck(ref string name, string subject, out string info)
        {
            if (String.IsNullOrEmpty(name))
            {
                info = "Podaj " + subject;
                return false;
            }
            name = name.ToLower();
            name = Char.ToUpper(name[0]) + name.Substring(1);
            if (!name.All(Char.IsLetter))
            {
                info = "Nieprawidłowe " + subject;
                return false;
            }
            if (name.Length > 25)
            {
                info = "Podane " + subject + " wydaje się zbyt długie,\n " +
                    "czy na pewno podano prawidłowe " + subject + "?";
                return false;
            }
            info = "";
            return true;
        }

        private bool LoginCheck(string login, out string info)
        {
            if (String.IsNullOrEmpty(login))
            {
                info = "Podaj login";
                return false;
            }
            if (!login.All(Char.IsLetterOrDigit))
            {
                info = "Nieprawidłowy login";
                return false;
            }
            if (login.Length > 15)
            {
                info = "Zbyt długi login";
                return false;
            }
            if (DatabaseConnector.IsInGuests(login))
            {
                info = "Podany login juz istnieje";
                return false;
            }
            info = "";
            return true;
        }

        private bool EmailCheck(string email, out string info)
        {
            if (String.IsNullOrEmpty(email))
            {
                info = "Podaj adres email";
                return false;
            }
            var parts = email.Split('@', '.', ' ');
            if (parts.Length > 3)
            {
                info = "Nieprawidłowy adres email";
                return false;
            }
            if (!parts[0].All(Char.IsLetterOrDigit) && !parts[1].All(Char.IsLetterOrDigit) && !parts[2].All(Char.IsLetterOrDigit))
            {
                info = "Nieprawidłowy adres email";
                return false;
            }
            if (!email.Contains("@") && !email.Contains("."))
            {
                info = "Nieprawidłowy adres email";
                return false;
            }
            if (email.Length > 40)
            {
                info = "Podany adres email wydaje się zbyt długi,\n" +
                    "czy na pewno podano prawidłowy adres email?";
                return false;
            }
            if (DatabaseConnector.IsInGuests(email))
            {
                info = "Podany adres email jest już w uzyciu";
                return false;
            }
            info = "";
            return true;
        }

        private bool PasswordCheck(string password, string repeat, out string info)
        {
            if (String.IsNullOrEmpty(password) | String.IsNullOrEmpty(repeat))
            {
                info = "Wprowadź hasło";
                return false;
            }
            if (!password.Equals(repeat))
            {
                info = "Hasła niezgodne";
                return false;
            }
            if ((string)passwordStrength.Content == "Słabe hasło")
            {
                info = "Hasło zbyt słabe";
                return false;
            }
            if (password.Length > 30)
            {
                info = "Hasło zbyt długie";
                return false;
            }
            info = "";
            return true;
        }

    }
}
