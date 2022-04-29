using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[0], CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Adam", Role = "Moderator", Age = 29, Marks = new int[0], CreatedAt = new DateTime(2021, 01, 13, 16, 00, 00), RemovedAt = new DateTime(2022, 04, 12, 19, 00, 00) },
                new User {Name = "Marques", Role = "Teacher", Age = 33, Marks = new int[0], CreatedAt = new DateTime(2022, 02, 22, 13, 30, 00), RemovedAt = new DateTime(2022, 04, 28, 17, 00, 00) },
                new User {Name = "David", Role = "Teacher", Age = 41, Marks = new int[0], CreatedAt = new DateTime(2021, 08, 22, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 21, 18, 00, 00) },
                new User {Name = "Ann", Role = "Teacher", Age = 38, Marks = new int[0], CreatedAt = new DateTime(2020, 03, 16, 19, 00, 00), RemovedAt = new DateTime(2021, 01, 26, 20, 00, 00) },
                new User {Name = "James", Role = "Teacher", Age = 42, Marks = new int[0], CreatedAt = new DateTime(2020, 02, 17, 12, 30, 00), RemovedAt = new DateTime(2022, 09, 22, 18, 00, 00) },
                new User {Name = "John", Role = "Student", Age = 19, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2021, 03, 05, 12, 00, 00), RemovedAt = new DateTime(2022, 03, 22, 20, 00, 00) },
                new User {Name = "Robert", Role = "Student", Age = 20, Marks = new int[6]{ 4, 5, 3, 3, 1, 5 }, CreatedAt = new DateTime(2021, 03, 11, 12, 00, 00), RemovedAt = new DateTime(2022, 03, 23, 18, 00, 00) },
                new User {Name = "Michael", Role = "Student", Age = 20, Marks = new int[5]{ 4, 3, 1, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) }
            };
        }


        

    }

    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}
