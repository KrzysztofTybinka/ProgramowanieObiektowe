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
            Update();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminStartingPage a = new AdminStartingPage();
            this.NavigationService.Navigate(a);
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWin w = new AddCategoryWin(this);
            w.Show();
        }

        private void RemoveCategory_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.RemoveCategoryBox())
            {
                DatabaseConnector.DeleteCategory((string)categoriesList.SelectedItem);
                Update();
            }
        }

        private void RemoveField_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddField_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddToReserve_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveToReserve_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Update()
        {
            categoriesList.ItemsSource = DatabaseConnector.SearchCategories();
        }
    }
}
