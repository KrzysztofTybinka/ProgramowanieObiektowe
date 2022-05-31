using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public static class Logged
    {
        private static User? user;

        public static User? User { get { return user; } }

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
            user = new User(g);
            return true;
        }

        /// <summary>
        /// Logs the user out by setting user field to null.
        /// </summary>
        public static void Logout()
        {
            user = null;
        }
    }
}
