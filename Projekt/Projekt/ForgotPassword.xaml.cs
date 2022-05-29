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
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Page
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EmailSender.SendRecoverPasswordCode(box.Text))
            {
                lowerInfo.Content = "Konto nie istnieje";
                lowerInfo.Foreground = Brushes.Red;
                box.Clear();
                return;
            }
            EmailSender.SendRecoverPasswordCode(box.Text);
            NewPassword n = new NewPassword(box.Text);
            this.NavigationService.Navigate(n);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            StartingPage s = new StartingPage();
            this.NavigationService.Navigate(s);
        }
    }
}
