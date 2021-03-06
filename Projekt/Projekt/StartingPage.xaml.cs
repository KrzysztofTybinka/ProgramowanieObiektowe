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
    /// Interaction logic for StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Page
    {
        /// <summary>
        /// Initializes main window.
        /// </summary>
        public StartingPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!LoggedGuest.Login(LoginBox.Text, PasswordBox.Password))
            {
                info.Content = "Nieprawidłowe dane";
                return;
            }
            if (LoggedGuest.Guest.IsAdmin)
            {
                AdminStartingPage a = new AdminStartingPage();
                this.NavigationService.Navigate(a);
            }
            else
            {
                GuestStartingPage u = new GuestStartingPage();
                this.NavigationService.Navigate(u);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            this.NavigationService.Navigate(r);
        }

        private void ForgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassword f = new ForgotPassword();
            this.NavigationService.Navigate(f);
        }
    }
}
