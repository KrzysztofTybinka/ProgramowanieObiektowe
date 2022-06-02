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
    /// Interaction logic for AddReservation.xaml
    /// </summary>
    public partial class AddReservation : Page
    {
        public AddReservation()
        {
            InitializeComponent();
            categoriesList.ItemsSource = DatabaseConnector.SearchCategories();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminStartingPage a = new AdminStartingPage();
            this.NavigationService.Navigate(a);
        }
    }
}
