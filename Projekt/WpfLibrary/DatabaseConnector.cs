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
        /// <returns>Array of strings containing all Categories rows.</returns>
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
        /// <returns>Returns true if category added succesfully, otherwise false.</returns>
        public static bool AddCategory(string input)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                if (input is null || input.Length > 25)
                    return false;
                try
                {
                    db.Categories.Add(new Categories { Category_Id = input });
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Removes category from Categories table.
        /// </summary>
        /// <param name="category"></param>
        public static void DeleteCategory(string category)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                if (category is null || category.Length > 25)
                    return;
                db.Categories.Remove(new Categories { Category_Id = category });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Selects for all items in Fields table.
        /// </summary>
        /// <returns>Array of strings containing all Fields rows.</returns>
        public static string[] SearchFields()
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                var fields = db.Fields.ToArray();
                var output = new string[fields.Length];

                for (int i = 0; i < fields.Length; i++)
                {
                    output[i] = "Id: " + Convert.ToString(fields[i].Field_Id) + "\n"
                        + "Nazwa: " + fields[i].Name + "\n"
                        + "Kategoria: " + fields[i].Category + "\n";
                }
                return output;
            }
        }

        /// <summary>
        /// Adds field to Fields table.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns true if field added succesfully, otherwise false.</returns>
        public static bool AddField(Fields field)
        {
            if (field is null)
                return false;
            using (BloggingContext db = new BloggingContext(conString))
            {
                try
                {
                    db.Fields.Add(field);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Deletes record with given id from Field table.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if item deleted, otherwise false.</returns>
        public static bool DeleteField(int id)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                var f = db.Fields.Where(x => x.Field_Id == id).FirstOrDefault();
                if (f is null)
                    return false;
                db.Fields.Remove(f);
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Selects for all items in ToReserve table.
        /// </summary>
        /// <returns>Array of strings containing all ToReserve rows.</returns>
        public static string[] SearchToReserve()
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                var arr = (from toReserve in db.ToReserve
                                join field in db.Fields on toReserve.Field equals field.Field_Id
                                where toReserve.Field == field.Field_Id
                                select new {Id = toReserve.ToReserve_Id, Field = field.Name, Date = toReserve.Date.ToShortDateString()}).ToArray();

                var output = new string[arr.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    output[i] = "Id: " + Convert.ToString(arr[i].Id) + "\n"
                        + "Nazwa: " + arr[i].Field + "\n"
                        + "Data: " + arr[i].Date + "\n";
                }
                return output;
            }
        }

        /// <summary>
        /// Adds record to ToReserve table.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns true if record added succesfully, otherwise false.</returns>
        public static bool AddToReserve(ToReserve toReserve)
        {
            if (toReserve is null)
                return false;
            using (BloggingContext db = new BloggingContext(conString))
            {
                try
                {
                    db.ToReserve.Add(toReserve);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Deletes record with given id from ToReserve table.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if item deleted, otherwise false.</returns>
        public static bool DeleteToReserve(int id)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                var f = db.ToReserve.Where(x => x.ToReserve_Id == id).FirstOrDefault();
                if (f is null)
                    return false;
                db.ToReserve.Remove(f);
                db.SaveChanges();
                return true;
            }
        }

        public static string[] SearchGuests()
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                var arr = db.Guests
                    .Where(x => !x.IsAdmin)
                    .Select(x => new 
                    {
                        Id = x.Guest_Id, 
                        Name = x.Name,
                        Surname = x.Surname,
                        Email = x.Email,
                        Login = x.Login,
                        Password = x.Password
                    }).ToArray();

                var output = new string[arr.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    output[i] = "Id: " + Convert.ToString(arr[i].Id) + "\n"
                        + "Imie: " + arr[i].Name + "\n"
                        + "Nazwisko: " + arr[i].Surname + "\n"
                        + "Email: " + arr[i].Email + "\n"
                        + "Login: " + arr[i].Login + "\n"
                        + "Hasło: " + arr[i].Password + "\n";
                }
                return output;
            }
        }

        public static Guests[] GuestsList()
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                return db.Guests.Where(x => !x.IsAdmin).ToArray();
            }
        }
            
    }
}
