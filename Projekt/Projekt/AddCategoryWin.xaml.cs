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
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for AddCategoryWin.xaml
    /// </summary>
    public partial class AddCategoryWin : Window
    {
        public delegate void AddCategoryEventHandler();
        public event AddCategoryEventHandler CategoryAdded;

        protected virtual void OnAddCategory()
        {
            if (CategoryAdded != null)
                CategoryAdded();
        }

        public AddCategoryWin(AddReservation sender)
        {
            InitializeComponent();
            CategoryAdded += sender.Update;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!DatabaseConnector.AddCategory(box.Text))
            {
                message.Foreground = Brushes.Red;
                message.Content = "Błąd przy dodawaniu kategorii";
                return;
            }
            OnAddCategory();
            this.Close();
        }
    }
}
