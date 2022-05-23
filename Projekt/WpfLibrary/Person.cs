using System;

namespace WpfLibrary
{
    public class Person
    {
        protected string login;
        protected string password;
        protected bool isAdmin;

        /// <summary>
        /// Gets user login.
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Gets user password.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Gets IsAdmin value
        /// </summary>
        /// <returns>True if user is admin, otherwise false.</returns>
        public bool IsAdmin { get { return isAdmin; } }

    }
}
