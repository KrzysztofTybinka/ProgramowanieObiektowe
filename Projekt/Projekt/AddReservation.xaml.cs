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
        public delegate void AddCategoryEventHandler();
        public event AddCategoryEventHandler CategoryAdded;

        protected virtual void OnAddCategory()
        {
            if (CategoryAdded != null)
                CategoryAdded();
        }
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

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWin w = new AddCategoryWin();
            w.Show();
        }
    }
}
