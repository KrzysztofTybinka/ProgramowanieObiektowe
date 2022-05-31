using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{

    public class User : Guests
    {
        public User()
        {

        }

        public User(Guests g)
        {
            Name = g.Name;
            Surname = g.Surname;
            Email = g.Email;
            Login = g.Login;
            Password = g.Password;
            IsAdmin = g.IsAdmin;
        }

        public User(string name, string surname, string email, string login, string password, bool isAdmin = false)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
        }

        public User(string name, string email, string login, string password)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
        }

        public User ConvertToUser(Guests g)
        {
            var u = new User();
            u.Name = g.Name;
            u.Email = g.Email;
            u.Login = g.Login;
            u.Password = g.Password;
            if(g.Surname is not null)
                u.Surname = g.Surname;
            return u;
        }
    }
}
