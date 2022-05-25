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
    }
}
