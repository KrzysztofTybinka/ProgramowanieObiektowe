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
    /// Interaction logic for GuestsList.xaml
    /// </summary>
    public partial class GuestsList : Page
    {
        public GuestsList()
        {
            InitializeComponent();
            list.ItemsSource = DatabaseConnector.SearchGuests();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            AdminStartingPage a = new AdminStartingPage();
            this.NavigationService.Navigate(a);
        }

        private void usersToXml_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem is null)
                return;
            if (MessageBoxes.DeleteUserBox())
            {
                string s = (string)list.SelectedItem;
                var arr = s.Split('\n', ' ');
                DatabaseConnector.RemoveGuestWithEmailOrLogin(arr[7]);
                list.ItemsSource = DatabaseConnector.SearchGuests();
            }
        }
    }
}
