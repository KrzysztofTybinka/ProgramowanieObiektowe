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
        public AddCategoryWin()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!DatabaseConnector.AddCategory(box.Text))
            {
                message.Foreground = Brushes.Red;
                message.Content = "Błąd przy dodawaniu kategorii";
                return;
            }
            Events addedEvent = new Events();
            AddReservation added = new AddReservation();
            addedEvent.CategoryAdded += added.Refresh;
            this.Close();
        }
    }
}
