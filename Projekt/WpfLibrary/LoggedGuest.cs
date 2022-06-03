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
            if (g.Password == null || !g.Password.Equals(password))
                return false;
            guest = g;
            return true;
        }

        /// <summary>
        /// Logs the user out by setting user field to null.
        /// </summary>
        public static void Logout()
        {
            guest = null;
        }
    }
}
