using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Projekt
{
    public class RegisterValidation
    {
        public static (string, SolidColorBrush) PasswordStrength(string input)
        {
            if (input == string.Empty)
                return ("", Brushes.Red);
            else if (input.Length < 8)
                return ("Słabe hasło", Brushes.Red);
            else if (input.Any(Char.IsUpper) && input.Any(Char.IsDigit) && input.Any(c => !Char.IsLetterOrDigit(c)))
                return ("Silne hasło", Brushes.Green);
            else if (input.Any(Char.IsUpper) && input.Any(Char.IsDigit))
                return ("Średnie hasło", Brushes.GreenYellow);
            else
                return ("Słabe hasło", Brushes.Red);
        }

        public static bool NameCheck(ref string name, string subject, out string info)
        {
            if (String.IsNullOrEmpty(name))
            {
                info = "Podaj " + subject;
                return false;
            }
            name = name.ToLower();
            name = Char.ToUpper(name[0]) + name.Substring(1);
            if (!name.All(Char.IsLetter))
            {
                info = "Nieprawidłowe " + subject;
                return false;
            }
            if (name.Length > 25)
            {
                info = "Podane " + subject + " wydaje się zbyt długie,\n " +
                    "czy na pewno podano prawidłowe " + subject + "?";
                return false;
            }
            info = "";
            return true;
        }

        public static bool LoginCheck(string login, out string info)
        {
            if (String.IsNullOrEmpty(login))
            {
                info = "Podaj login";
                return false;
            }
            if (!login.All(Char.IsLetterOrDigit))
            {
                info = "Nieprawidłowy login";
                return false;
            }
            if (login.Length > 15)
            {
                info = "Zbyt długi login";
                return false;
            }
            if (DatabaseConnector.IsInGuests(login))
            {
                info = "Podany login juz istnieje";
                return false;
            }
            info = "";
            return true;
        }

        public static bool EmailCheck(string email, out string info)
        {
            if (String.IsNullOrEmpty(email))
            {
                info = "Podaj adres email";
                return false;
            }
            var parts = email.Split('@', '.', ' ');
            if (parts.Length > 3)
            {
                info = "Nieprawidłowy adres email";
                return false;
            }
            if (!parts[0].All(Char.IsLetterOrDigit) && !parts[1].All(Char.IsLetterOrDigit) && !parts[2].All(Char.IsLetterOrDigit))
            {
                info = "Nieprawidłowy adres email";
                return false;
            }
            if (!email.Contains("@") && !email.Contains("."))
            {
                info = "Nieprawidłowy adres email";
                return false;
            }
            if (email.Length > 40)
            {
                info = "Podany adres email wydaje się zbyt długi,\n" +
                    "czy na pewno podano prawidłowy adres email?";
                return false;
            }
            if (DatabaseConnector.IsInGuests(email))
            {
                info = "Podany adres email jest już w uzyciu";
                return false;
            }
            info = "";
            return true;
        }

        public static bool PasswordCheck(string password, string repeat, out string info)
        {
            if (String.IsNullOrEmpty(password) | String.IsNullOrEmpty(repeat))
            {
                info = "Wprowadź hasło";
                return false;
            }
            if (!password.Equals(repeat))
            {
                info = "Hasła niezgodne";
                return false;
            }
            if ((string)passwordStrength.Content == "Słabe hasło")
            {
                info = "Hasło zbyt słabe";
                return false;
            }
            if (password.Length > 30)
            {
                info = "Hasło zbyt długie";
                return false;
            }
            info = "";
            return true;
        }
    }
}
