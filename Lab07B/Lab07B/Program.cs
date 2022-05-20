using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab07B
{
    internal class Program
    {
        //user controls
        public static string connectionString = @"Data Source=localhost;Initial Catalog=SportsComplex;Integrated Security=True";
        static void Main(string[] args)
        {
            

            using (BloggingContext db = new BloggingContext(connectionString))
            {
                // Create
                Console.WriteLine("Inserting data...");
                db.Add(new Guests { Name = "Steven", Surname = "Brown", Email = "steven@saintly.org", Login = "steven1", Password = "Abc123$#ss" });
                //   db.Add(new Categories { Category = "Tennis Court" });
                Categories ccc = new Categories { Category = "Tennis Court" };
                db.Add(ccc);
                db.SaveChanges();
                db.Add(new Fields { Name = "Court No. 1", Category = ccc.Category_Id });
                //db.Add(new Fields { Name = "Court No. 1", Category = CategorySearch("Tennis Court") });
                db.SaveChanges();
                db.Add(new ToReserve { Field = FieldSearch("Court No. 1"), Date = new DateTime(2022, 05, 26, 19, 00, 00) });
                db.SaveChanges();
                db.Add(new Reservations { Guest = GuestSearch("Steven"), ToReserve = ToReserveSearch(new DateTime(2022, 05, 26, 19, 00, 00)) });
                db.SaveChanges();

                //Read
                Console.WriteLine("Querying for reservations...");
                Console.WriteLine(String.Join(", ", 
                    from reservations in db.Reservations
                    join guests in db.Guests on reservations.Guest equals guests.Guest_Id
                    where reservations.Guest == guests.Guest_Id
                    join toreserve in db.ToReserve on reservations.ToReserve equals toreserve.ToReserve_Id
                    where reservations.ToReserve == toreserve.ToReserve_Id
                    join fields in db.Fields on toreserve.Field equals fields.Field_Id
                    where toreserve.Field == fields.Field_Id
                    select new {Name = guests.Name, Field_Name = fields.Name, Date = toreserve.Date}));

                //Update
                Console.WriteLine("Updating user e-mail...");
                var user = db.Guests
                    .Where(x => x.Guest_Id == GuestSearch("Steven"))
                    .OrderBy(x => x.Guest_Id)
                    .FirstOrDefault();
                user.Email = "steven122@saintly.org";
                db.SaveChanges();

                //Delete
                Console.WriteLine("Deleting user...");
                db.Remove(user);
                db.SaveChanges();
                

            }
        }

        static int CategorySearch(string category)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                return db.Categories
                    .Where(x => category.Equals(x.Category))
                    .Select(x => x.Category_Id)
                    .ToArray()[0];
            }
        }

        static int FieldSearch(string name)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                return db.Fields
                    .Where(x => name.Equals(x.Name))
                    .Select(x => x.Field_Id)
                    .ToArray()[0];
            }
        }

        static int GuestSearch(string name)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                return db.Guests
                    .Where(x => x.Name.Equals(name))
                    .Select(x => x.Guest_Id)
                    .ToArray()[0];
            }
        }

        static int ToReserveSearch(DateTime date)
        {
            using (BloggingContext db = new BloggingContext(connectionString))
            {
                return db.ToReserve
                    .Where(x => x.Date.Equals(date))
                    .Select(x => x.ToReserve_Id)
                    .ToArray()[0];
            }
        }




    }
}
