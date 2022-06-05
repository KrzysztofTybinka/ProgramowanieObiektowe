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
    /// Interaction logic for AdminStartingPage.xaml
    /// </summary>
    public partial class AdminStartingPage : Page
    {
        public AdminStartingPage()
        {
            InitializeComponent();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.LogOutBox())
            {
                StartingPage s = new StartingPage();
                this.NavigationService.Navigate(s);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddReservation_Click(object sender, RoutedEventArgs e)
        {
            AddReservation a = new AddReservation();
            this.NavigationService.Navigate(a);
        }

        private void GuestList_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
