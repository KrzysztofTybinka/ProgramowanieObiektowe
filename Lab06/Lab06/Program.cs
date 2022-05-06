using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = User.GenerateList();

            //zad 1
            Console.WriteLine($"1. Number of elements in the list: {users.Count()}" + "\n");

            //zad 2
            Console.WriteLine("2. People names:" + "\n" +
                String.Join("\n", users.Select(x => x.Name)) + "\n");

            //zad 3
            Console.WriteLine("3. Sorted by names:" + "\n" +
                String.Join("\n", users.OrderBy(x => x.Name)
                .Select(x => x.Name)) + "\n");

            //zad 4
            Console.WriteLine("4. Available roles:" + "\n" +
                String.Join("\n", users.Select(x => x.Role)
                .Distinct()) + "\n");

            //zad 5
            Console.WriteLine("5. Users grouped by roles:");
            foreach (var item in users.GroupBy(x => x.Role))
            {
                Console.WriteLine(item.Key + ":" + "\n" +
                    String.Join("\n", users.Where(x => x.Role == item.Key)
                    .Select(x => x.Name)) + "\n");
            }

            //zad 6
            Console.Write("6. Amount of people on the list with grades: " +
                users.Where(x => x.Marks.Length > 0)
                .Count() + "\n" + "\n");

            //zad 7
            Console.WriteLine("7. Sum, amount and mean of all student grades" + "\n" +
                "Sum: " + users.Sum(x => x.Marks.Sum()) + "\n" +
                "Amount: " + users.Sum(x => x.Marks.Length) + "\n" +
                "Average: " + Math.Round(users.Where(x => x.Marks.Length > 0)
                .Average(x => x.Marks.Average()), 2) + "\n");

            //zad 8
            Console.WriteLine("8. Best grade: " + 
                users.Where(x => x.Marks.Length > 0)
                .Max(x => x.Marks.Max()) + "\n");

            //zad 9
            Console.WriteLine("9. Worst grade: " + 
                users.Where(x => x.Marks.Length > 0)
                .Min(x => x.Marks.Min()) + "\n");

            //zad 10
            Console.WriteLine("10. Best student: " +
                users.Where(x => x.Marks.Length > 0)
                .OrderByDescending(x => x.Marks.Average())
                .Select(x => x.Name)
                .First() + "\n");

            //zad 11
            Console.WriteLine("11. Students with least grades: " + "\n" +
                String.Join("\n", users.Where(x => x.Marks.Length > 0)
                .OrderBy(x => x.Marks.Length)
                .GroupBy(x => x.Marks.Length)
                .First()
                .Select(x => x.Name)) + "\n");

            //zad 12
            Console.WriteLine("12. Students with most grades: " + "\n" +
                String.Join("\n", users.Where(x => x.Marks.Length > 0)
                .OrderByDescending(x => x.Marks.Length)
                .GroupBy(x => x.Marks.Length)
                .First()
                .Select(x => x.Name)) + "\n");

            //zad 13
            Console.WriteLine("13. Students and their average grade:" + "\n" +
                String.Join("\n", users.Where(x => x.Marks.Length > 0)
                .Select(x => new
                {
                    x.Name,
                    AverageGrade = Math.Round(x.Marks.Average(), 2)
                })) + "\n");

            //zad 14
            Console.WriteLine("14. Students from best to worst:" + "\n" +
            String.Join("\n", users.Where(x => x.Marks.Length > 0)
            .OrderByDescending(x => x.Marks.Average())
            .Select(x => x.Name)) + "\n");

            //zad 15
            Console.WriteLine("15. Average grade of all students: " + 
                Math.Round(users.Where(x => x.Marks.Length > 0)
                .Average(x => x.Marks.Average()), 2) + "\n");

            //zad 16
            Console.WriteLine("16. People sorted by creation date: " + "\n" +
                String.Join("\n", users.GroupBy(x => x.CreatedAt.Value.Year + '-' + x.CreatedAt.Value.Month)
                .Select(x => x.Key)) + "\n");

            //zad 17
            Console.WriteLine("17. People that haven't been removed: " + "\n" +
                String.Join("\n", users.Where(x => x.RemovedAt == null)
                .Select(x => x.Name)) + "\n");

            //zad 18
            Console.WriteLine("18. Latest student: " +
                users.Where(x => x.Marks.Length > 0)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => x.Name)
                .First());
            
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

        static public List<User> GenerateList()
        {
            return new List<User>()
            {
                new User {Name = "Mark", Role = "Admin", Age = 25, Marks = new int[0], CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = null },
                new User {Name = "Adam", Role = "Moderator", Age = 29, Marks = new int[0], CreatedAt = new DateTime(2021, 01, 13, 16, 00, 00), RemovedAt = new DateTime(2022, 04, 12, 19, 00, 00) },
                new User {Name = "Marques", Role = "Teacher", Age = 33, Marks = new int[0], CreatedAt = new DateTime(2022, 02, 22, 13, 30, 00), RemovedAt = null },
                new User {Name = "David", Role = "Teacher", Age = 41, Marks = new int[0], CreatedAt = new DateTime(2021, 08, 22, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 21, 18, 00, 00) },
                new User {Name = "Ann", Role = "Teacher", Age = 38, Marks = new int[0], CreatedAt = new DateTime(2020, 03, 16, 19, 00, 00), RemovedAt = null },
                new User {Name = "James", Role = "Teacher", Age = 42, Marks = new int[0], CreatedAt = new DateTime(2020, 02, 17, 12, 30, 00), RemovedAt = new DateTime(2022, 09, 22, 18, 00, 00) },
                new User {Name = "John", Role = "Student", Age = 19, Marks = new int[5]{ 4, 5, 5, 3, 1 }, CreatedAt = new DateTime(2021, 03, 05, 12, 00, 00), RemovedAt = new DateTime(2022, 03, 22, 20, 00, 00) },
                new User {Name = "Robert", Role = "Student", Age = 20, Marks = new int[6]{ 4, 5, 3, 3, 1, 5 }, CreatedAt = new DateTime(2021, 03, 11, 12, 00, 00), RemovedAt = new DateTime(2022, 03, 23, 18, 00, 00) },
                new User {Name = "Michael", Role = "Student", Age = 20, Marks = new int[5]{ 4, 3, 1, 3, 1 }, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 17, 18, 00, 00) },
                new User {Name = "Linda", Role = "Student", Age = 23, Marks = new int[7]{ 3, 2, 2, 3, 1, 5, 4 }, CreatedAt = new DateTime(2022, 02, 03, 16, 00, 00), RemovedAt = new DateTime(2022, 03, 12, 18, 00, 00) },
                new User {Name = "Charles", Role = "Student", Age = 23, Marks = new int[4]{ 2, 5, 5, 1}, CreatedAt = new DateTime(2022, 01, 12, 16, 00, 00), RemovedAt = new DateTime(2022, 04, 01, 18, 00, 00) },
                new User {Name = "Lisa", Role = "Student", Age = 21, Marks = new int[5]{ 4, 5, 3, 3, 1 }, CreatedAt = new DateTime(2022, 02, 01, 16, 00, 00), RemovedAt = new DateTime(2022, 03, 21, 18, 00, 00) },
                new User {Name = "Paul", Role = "Student", Age = 19, Marks = new int[5]{ 4, 5, 5, 4, 5 }, CreatedAt = new DateTime(2022, 01, 22, 16, 00, 00), RemovedAt = new DateTime(2022, 01, 13, 18, 00, 00) },
                new User {Name = "Larry", Role = "Student", Age = 21, Marks = new int[8]{ 2, 3, 3, 3, 1, 4, 3, 2 }, CreatedAt = new DateTime(2022, 01, 18, 16, 00, 00), RemovedAt = new DateTime(2022, 03, 19, 18, 00, 00) },
                new User {Name = "Andrew", Role = "Student", Age = 21, Marks = new int[7]{ 1, 1, 5, 3, 1, 4, 4 }, CreatedAt = new DateTime(2022, 01, 17, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 04, 18, 00, 00) },
                new User {Name = "Michelle", Role = "Student", Age = 20, Marks = new int[4]{ 2, 5, 4, 3}, CreatedAt = new DateTime(2022, 02, 12, 16, 00, 00), RemovedAt = null },
                new User {Name = "Brandon", Role = "Student", Age = 21, Marks = new int[4]{ 4, 3, 5, 3 }, CreatedAt = new DateTime(2022, 02, 20, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 15, 18, 00, 00) },
                new User {Name = "Helen", Role = "Student", Age = 20, Marks = new int[6]{ 4, 4, 4, 3, 1, 3 }, CreatedAt = new DateTime(2022, 01, 11, 16, 00, 00), RemovedAt = new DateTime(2022, 02, 18, 18, 00, 00) },
                new User {Name = "Emma", Role = "Student", Age = 22, Marks = new int[5]{ 4, 1, 3, 3, 1 }, CreatedAt = new DateTime(2022, 01, 28, 16, 00, 00), RemovedAt = null },
                new User {Name = "Jannet", Role = "Student", Age = 23, Marks = new int[7]{ 4, 2, 3, 3, 1, 4, 4 }, CreatedAt = new DateTime(2022, 01, 22, 16, 00, 00), RemovedAt = new DateTime(2022, 03, 20, 18, 00, 00) }
            };
        }
    }
}
