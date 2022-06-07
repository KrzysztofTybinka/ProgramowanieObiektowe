using System.Windows;


namespace Projekt
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            if (!RegisterValidation.PasswordCheck(newPassword.Password, repeatNewPass.Password, (string)info.Content, out string infoPassword))
            {
                newPassword.Clear();
                newPassword.Clear();
                MessageBox.Show(infoPassword);
                return;
            }
            if (oldPassword.Password != LoggedGuest.Guest.Password)
            {
                MessageBox.Show("Wprowadziłeś złe hasło");
                oldPassword.Clear();
                return;
            }
            DatabaseConnector.ChangePassword(newPassword.Password, LoggedGuest.Guest.Login);
            MessageBox.Show("Hasło zmienione");
            this.Close();
        }

        private void newPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var v = RegisterValidation.PasswordStrength(newPassword.Password);
            info.Content = v.Item1;
            info.Foreground = v.Item2;
        }
    }
}
