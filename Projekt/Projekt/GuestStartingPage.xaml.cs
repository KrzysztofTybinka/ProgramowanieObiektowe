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
    /// Interaction logic for GuestStartingPage.xaml
    /// </summary>
    public partial class GuestStartingPage : Page
    {
        public GuestStartingPage()
        {
            InitializeComponent();
            list.ItemsSource = DatabaseConnector.SearchToReserve();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.LogOutBox())
            {
                StartingPage s = new StartingPage();
                this.NavigationService.Navigate(s);
            }
        }

        private void myProfile_Click(object sender, RoutedEventArgs e)
        {
            GuestMyProfile g = new GuestMyProfile();
            this.NavigationService.Navigate(g);
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            list.ItemsSource = DatabaseConnector.SearchToReserve().Where(x => x.Contains(box.Text)); 
        }

        private void book_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.Book())
            {
                var s = (string)list.SelectedItem;
                var a = s.Split('\n', ' ');
                if (!DatabaseConnector.AddReservation(LoggedGuest.Guest.Guest_Id, Convert.ToInt32(a[1])))
                    MessageBox.Show("Coś poszło nie tak");
                list.ItemsSource = DatabaseConnector.SearchToReserve();
                LoggedGuest.SearchReservations();
            }
        }
    }
}
