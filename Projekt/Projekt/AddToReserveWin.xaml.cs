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
    /// Interaction logic for AddToReserveWin.xaml
    /// </summary>
    public partial class AddToReserveWin : Window
    {
        public delegate void AddToReserveEventHandler();
        public event AddToReserveEventHandler ToReserveAdded;

        protected virtual void OnAddCategory()
        {
            if (ToReserveAdded != null)
                ToReserveAdded();
        }
        public AddToReserveWin(AddReservation sender)
        {
            InitializeComponent();
            ToReserveAdded += sender.Update;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!DatabaseConnector.AddToReserve
                (new ToReserve 
                {
                    Field = Convert.ToInt32(fieldBox.Text),
                    Date = Convert.ToDateTime(dateBox.Text) 
                }))
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
