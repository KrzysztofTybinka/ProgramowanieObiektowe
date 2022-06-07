
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
            reservationList.ItemsSource = DatabaseConnector.SearchReservations();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.LogOutBox())
            {
                StartingPage s = new StartingPage();
                this.NavigationService.Navigate(s);
            }
        }

        private void AddReservation_Click(object sender, RoutedEventArgs e)
        {
            AddReservation a = new AddReservation();
            this.NavigationService.Navigate(a);
        }

        private void GuestList_Click(object sender, RoutedEventArgs e)
        {
            GuestsList g = new GuestsList();
            this.NavigationService.Navigate(g);
        }

        private void deleteReservation_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.DeleteReservationBox())
            {
                string s = (string)reservationList.SelectedItem;
                var arr = s.Split('\n', ' ');
                DatabaseConnector.DeleteReservation(Convert.ToInt32(arr[2]), Convert.ToInt32(arr[5]));
                reservationList.ItemsSource = DatabaseConnector.SearchReservations();
            }
        }
    }
}
