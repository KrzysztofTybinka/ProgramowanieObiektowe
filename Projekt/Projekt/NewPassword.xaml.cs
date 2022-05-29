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
    /// Interaction logic for NewPassword.xaml
    /// </summary>
    public partial class NewPassword : Page
    {
        private string email;
        public NewPassword(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassword f = new ForgotPassword();
            this.NavigationService.Navigate(f);
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (code.Text.Length != 4)
            {
                info.Foreground = Brushes.Red;
                info.Content = "Kod nieprawidłowy";
                code.Clear();
                return;
            }
            if (Convert.ToInt32(code.Text) != EmailSender.Code)
            {
                info.Foreground = Brushes.Red;
                info.Content = "Kod nieprawidłowy";
                code.Clear();
                return;
            }
            if(!RegisterValidation.PasswordCheck(password.Password, repPassword.Password, RegisterValidation.PasswordStrength(password.Password).Item1, out string msg))
            {
                info.Foreground = Brushes.Red;
                info.Content = msg;
                password.Clear();
                repPassword.Clear();
                return;
            }
            info.Foreground = Brushes.Green;
            info.Content = "Hasło zmienione";
            DatabaseConnector.ChangePassword(password.Password, email);
        }
    }
}
