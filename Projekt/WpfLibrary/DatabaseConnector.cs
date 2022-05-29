using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class DatabaseConnector
    {
        public static string conString = @"Data Source=LAPTOP-CNL6SERI;Initial Catalog=SportsComplex;Integrated Security=True";

        /// <summary>
        /// Changes user password to a new given password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public static void ChangePassword(string password, string email)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                var g = db.Guests.Where(x => email.Equals(x.Email)).FirstOrDefault();
                if(g is not null)
                    g.Password = password;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Searches guest in a database using input email address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Guests? GuestByEmail(string email)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                return db.Guests.Where(x => email.Equals(x.Email)).FirstOrDefault();                   
            }
        }

        /// <summary>
        /// Inserts guest into a database.
        /// </summary>
        /// <param name="u"></param>
        public static void InsertGuest(User u)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                db.Add(new Guests
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    Login = u.Login,
                    Password = u.Password,
                    IsAdmin = false
                }); 
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Evaluates whether given username or e-mail is already in a database.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True if is, otherwise false.</returns>
        public static bool IsInGuests(string name)
        {            
            using (BloggingContext db = new BloggingContext(conString))
            {
                if (name.Contains('@'))
                {
                    if (db.Guests.Where(x => name.Equals(x.Email)).Count() > 0)
                        return true;
                }
                else
                {
                    if (db.Guests.Where(x => name.Equals(x.Login)).Count() > 0)
                        return true;
                }
                return false;                      
            }



        }
    }
}
