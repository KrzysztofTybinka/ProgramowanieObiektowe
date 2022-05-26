using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class User : Person
    {
        private string name;
        private string surname;
        private string email;

        /// <summary>
        /// Gets user name.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Gets user surname.
        /// </summary>
        public string Surname { get { return surname; } }

        /// <summary>
        /// Gets user email.
        /// </summary>
        public string Email { get { return email; } }
    }
}
