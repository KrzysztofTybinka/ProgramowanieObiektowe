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
    /// Interaction logic for AddFieldWin.xaml
    /// </summary>
    public partial class AddFieldWin : Window
    {
        public delegate void AddFieldEventHandler();
        public event AddFieldEventHandler FieldAdded;

        protected virtual void OnAddCategory()
        {
            if (FieldAdded != null)
                FieldAdded();
        }

        public AddFieldWin(AddReservation sender)
        {
            InitializeComponent();
            FieldAdded += sender.Update;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!DatabaseConnector.AddField(new Fields { Name = nameBox.Text, Category = categoryBox.Text }))
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
