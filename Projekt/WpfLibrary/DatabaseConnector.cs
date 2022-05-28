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
                    IsAdmin = 0 
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
