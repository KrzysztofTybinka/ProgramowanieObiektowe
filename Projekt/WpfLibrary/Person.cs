using System;

namespace Projekt
{
    public class Person
    {
        /// <summary>
        /// Gets user login.
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Gets user password.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets IsAdmin value
        /// </summary>
        /// <returns>True if user is admin, otherwise false.</returns>
        public bool IsAdmin { get; set; }

    }
}
