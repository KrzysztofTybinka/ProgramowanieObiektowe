using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        //CRUD - create, read, update, delete
        //atrybuty, refleksja
        static void Main(string[] args)
        {
            //TODO: change DESKTOP-123ABC\SQLEXPRESS
            string connectionString = @"Data Source=DESKTOP-123ABC\SQLEXPRESS;Initial Catalog=blogdb;Integrated Security=True";

            using (BloggingContext db = new BloggingContext(connectionString))
            {
                Console.WriteLine($"Database ConnectionString: {db.ConnectionString}.");

                // Create
                Console.WriteLine("Inserting a new blog");

                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");

                Blog blog = db.Blogs
                    .OrderBy(b => b.Id)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");

                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");

                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}
