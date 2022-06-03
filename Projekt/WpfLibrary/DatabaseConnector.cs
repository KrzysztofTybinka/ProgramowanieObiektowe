using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt
{
    public class DatabaseConnector
    {
        public static string conString = @"Data Source=LAPTOP-CNL6SERI;Initial Catalog=SportsComplex;Integrated Security=True";

        /// <summary>
        /// Changes user password to a new given password,
        /// identifies user with password to change with
        /// login or email address.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public static void ChangePassword(string password, string identifier)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                if (identifier.Contains('@'))
                {
                    var g = db.Guests.Where(x => identifier.Equals(x.Email)).FirstOrDefault();
                    if (g is not null)
                        g.Password = password;
                    db.SaveChanges();
                }
                else
                {
                    var g = db.Guests.Where(x => identifier.Equals(x.Login)).FirstOrDefault();
                    if (g is not null)
                        g.Password = password;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Searches guest in a database using input email address or login.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Guest if found, otherwise null.</returns>
        public static Guests? GuestByEmailOrLogin(string identifier)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                if (String.IsNullOrEmpty(identifier))
                    return null;
                if (identifier.Contains('@'))
                    return db.Guests.Where(x => identifier.Equals(x.Email)).FirstOrDefault();
                return db.Guests.Where(x => identifier.Equals(x.Login)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Inserts guest into a database if possible.
        /// </summary>
        /// <param name="g"></param>
        /// <returns>True if user has been inserted, otherwise false.</returns>
        public static bool InsertGuest(Guests g)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                if (g is null)
                    return false;
                if (IsInGuests(g.Login!) | IsInGuests(g.Email!))
                    return false;
                db.Add(g);
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Evaluates whether given user is 
        /// already in a database based on given 
        /// email address or login.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns>True if is, otherwise false.</returns>
        public static bool IsInGuests(string identifier)
        {            
            using (BloggingContext db = new BloggingContext(conString))
            {
                if (identifier.Contains('@'))
                {
                    if (db.Guests.Where(x => identifier.Equals(x.Email)).Any())
                        return true;
                }
                else
                {
                    if (db.Guests.Where(x => identifier.Equals(x.Login)).Any())
                        return true;
                }
                return false;                      
            }
        }

        /// <summary>
        /// Evaluates whether given user is already in database.
        /// </summary>
        /// <param name="guest"></param>
        /// <returns>True if is, otherwise false.</returns>
        public static bool IsInGuests(Guests guest)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                if (db.Guests.Where(x => guest.Email.Equals(x.Email)).Any())
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Removes guest from a database identified by 
        /// login or email address if exists.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns>True if guest has been removed, otherwise false.</returns>
        public static bool RemoveGuestWithEmailOrLogin(string identifier)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                var g = GuestByEmailOrLogin(identifier);
                if (g is null)
                    return false;
                db.Remove(g);
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Selects for all items in Categories table.
        /// </summary>
        /// <returns>Array of strins containing all categories.</returns> //dopisac testy
        public static string?[] SearchCategories()
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                var output = db.Categories
                    .Select(x => x.Category_Id)
                    .ToArray();
                return output;
            }
        }

        /// <summary>
        /// Adds category to Categories table.
        /// </summary>
        /// <param name="input"></param>
        public static void AddCategory(string input)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                if (input is null)
                {
                    MessageBox.Show("Podaj nazwę kategorii");
                    return;
                }
                if (input.Length > 25)
                {
                    MessageBox.Show("Nazwa jest zbyt długa");
                    return;
                }
                db.Categories.Add(new Categories { Category_Id = input });
            }
        }
    }
}
