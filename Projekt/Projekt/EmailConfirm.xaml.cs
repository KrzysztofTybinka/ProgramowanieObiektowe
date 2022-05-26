﻿using System;
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
    /// Interaction logic for EmailConfirm.xaml
    /// </summary>
    public partial class EmailConfirm : Page
    {
        public EmailConfirm()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            StartingPage p = new StartingPage();
            this.NavigationService.Navigate(p);
        }

        private void sendAgain_Click(object sender, RoutedEventArgs e)
        {

        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            if (codeBox.Text.Length != 4)
            {
                message.Foreground = Brushes.Red;
                message.Content = "Kod nieprawidłowy";
            }
            if (Convert.ToInt32(codeBox.Text) != ConfirmationCode.Code)
            {
                message.Foreground = Brushes.Red;
                message.Content = "Kod nieprawidłowy";
            }
        }
    }
}