using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public static class LoggedGuest
    {
        private static Guests? guest;
        private static string[]? reservations;

        public static string[]? Reservations { get { return reservations; } }
        public static Guests? Guest { get { return guest; } }

        /// <summary>
        /// Validates user login and password, logs the user 
        /// in by setting user field as the current user.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>True if login operation was succesfull, otherwise false.</returns>
        public static bool Login(string login, string password)
        {
            var g = DatabaseConnector.GuestByEmailOrLogin(login);
            if (g == null || !g.Password.Equals(password))
                return false;
            guest = g;
            SearchReservations();
            return true;
        }

        /// <summary>
        /// Logs the user out by setting user field to null.
        /// </summary>
        public static void Logout()
        {
            guest = null;
        }

        /// <summary>
        /// Initializes currently logged Guest Reservations string array.
        /// </summary>
        public static void SearchReservations()
        {
            var arr = DatabaseConnector.SearchReservations();
            var list = new List<string>();

            foreach (var reservation in arr)
            {
                var s = reservation.Split(' ', '\n');
                if (Convert.ToInt32(s[2]) == guest!.Guest_Id)
                {
                    list.Add(reservation);
                }
            }
            reservations = list.ToArray();
        }

        /// <summary>
        /// Returns a string containing basic information
        /// about currently logged guest.
        /// </summary>
        /// <returns>String containing information about logged guest.</returns>
        public static string GuestInfo()
        {
            return "Imie: " + guest!.Name + "\n"
                + "Nazwisko: " + guest.Surname + "\n"
                + "Email: " + guest.Email + "\n";               
        }

    }
}
