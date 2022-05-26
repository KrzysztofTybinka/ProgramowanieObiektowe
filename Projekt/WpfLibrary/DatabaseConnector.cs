﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class DatabaseConnector
    {
        public static string conString = @"Data Source=LAPTOP-CNL6SERI;Initial Catalog=SportsComplex;Integrated Security=True";

        public static void InsertGuests(string name, string surname, string email, string login, string password, int isAdmin = 0)
        {
            using (BloggingContext db = new BloggingContext(conString))
            {
                db.Add(new Guests { Name = name, Surname = surname, Email = email, Login = login, Password = password, IsAdmin = isAdmin });
                db.SaveChanges();
            }
        }

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
                    if (db.Guests.Where(x => name.Equals(x.Name)).Count() > 0)
                        return true;
                }
                return false;                      
            }



        }
    }
}