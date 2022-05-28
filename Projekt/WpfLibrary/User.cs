using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class User : Person
    {
        /// <summary>
        /// Gets user name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets user surname.
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Gets user email.
        /// </summary>
        public string? Email { get; set; }
    }
}
