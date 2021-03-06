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
            if (categoriesList.SelectedItem is null)
                return;
            if (MessageBoxes.RemoveCategoryBox())
            {
                DatabaseConnector.DeleteCategory((string)categoriesList.SelectedItem);
                Update();
            }
        }

        private void AddField_Click(object sender, RoutedEventArgs e)
        {
            AddFieldWin w = new AddFieldWin(this);
            w.Show();
        }

        private void RemoveField_Click(object sender, RoutedEventArgs e)
        {
            if (roomsList.SelectedItem is null)
                return;
            if (MessageBoxes.RemoveFieldBox())
            {
                string s = (string)roomsList.SelectedItem;
                var arr = s.Split('\n', ' ');
                DatabaseConnector.DeleteField(Convert.ToInt32(arr[1]));
                Update();
            }
        }

        private void AddToReserve_Click(object sender, RoutedEventArgs e)
        {
            AddToReserveWin w = new AddToReserveWin(this);
            w.Show();
        }

        private void RemoveToReserve_Click(object sender, RoutedEventArgs e)
        {
            if (bookList.SelectedItem is null)
                return;
            if (MessageBoxes.RemoveToReserveBox())
            {
                string s = (string)roomsList.SelectedItem;
                var arr = s.Split('\n', ' ');
                DatabaseConnector.DeleteToReserve(Convert.ToInt32(arr[1]));
                Update();
            }
        }

        public void Update()
        {
            categoriesList.ItemsSource = DatabaseConnector.SearchCategories();
            roomsList.ItemsSource = DatabaseConnector.SearchFields();
            bookList.ItemsSource = DatabaseConnector.SearchToReserve();
        }
    }
}
