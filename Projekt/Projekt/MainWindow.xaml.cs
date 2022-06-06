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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes new window and displays starting page on it.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DatabaseConnector.UpdateToReserve();
            var p = new StartingPage();
            Main.NavigationService.Navigate(p);
        }

    }
}
