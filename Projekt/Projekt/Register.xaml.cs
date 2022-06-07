using System.Windows;
using System.Windows.Controls;


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
            if (!RegisterValidation.PasswordCheck(passwordBox.Password, repPasswordBox.Password, (string)passwordStrength.Content, out string infoPassword))
            {
                passwordBox.Clear();
                repPasswordBox.Clear();
                infoBox.Content = infoPassword;
                return;
            }
            EmailConfirm p = new EmailConfirm(new Guests()
            {
                Login = loginBox.Text,
                Password = passwordBox.Password,
                Email = emailBox.Text,
                Name = name,
                Surname = surname,
                IsAdmin = false
            });
            this.NavigationService.Navigate(p);                        
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var v = RegisterValidation.PasswordStrength(passwordBox.Password);
            passwordStrength.Content = v.Item1;
            passwordStrength.Foreground = v.Item2;
        }


    }
}
