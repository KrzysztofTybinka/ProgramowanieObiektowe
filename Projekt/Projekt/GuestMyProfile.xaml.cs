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
    /// Interaction logic for GuestMyProfile.xaml
    /// </summary>
    public partial class GuestMyProfile : Page
    {
        public GuestMyProfile()
        {
            InitializeComponent();
            Update();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            GuestStartingPage g = new GuestStartingPage();
            this.NavigationService.Navigate(g);
        }

        private void changePass_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelReservation_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.DeleteReservationBox())
            {
                var s = Convert.ToInt32(((string)myReservations.SelectedItem).Split(' ', '\n')[5]);
                if (!DatabaseConnector.DeleteReservation(LoggedGuest.Guest.Guest_Id, s))
                    MessageBox.Show("Coś poszło nie tak");
                LoggedGuest.SearchReservations();
                Update();
            }
        }

        private void Update()
        {
            myData.Content = LoggedGuest.GuestInfo();
            myReservations.ItemsSource = LoggedGuest.Reservations;
        }
    }
}
