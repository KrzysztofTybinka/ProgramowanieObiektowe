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
            if (passwordBox.Password == string.Empty)
            {
                passwordStrength.Content = "";
            }
            else if (passwordBox.Password.Length < 8)
            {
                passwordStrength.Content = "Słabe hasło";
                passwordStrength.Foreground = Brushes.Red;
            }
            else if (passwordBox.Password.Any(Char.IsUpper) && passwordBox.Password.Any(Char.IsDigit) && passwordBox.Password.Any(c => !Char.IsLetterOrDigit(c)))
            {
                passwordStrength.Content = "Silne hasło";
                passwordStrength.Foreground = Brushes.Green;
            }
            else if (passwordBox.Password.Any(Char.IsUpper) && passwordBox.Password.Any(Char.IsDigit))
            {
                passwordStrength.Content = "Średnie hasło";
                passwordStrength.Foreground = Brushes.GreenYellow;
            }
            else
            {
                passwordStrength.Content = "Słabe hasło";
                passwordStrength.Foreground = Brushes.Red;
            }
        }
    }
}
