using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07
{
    internal class Program
    {
        static string connectionString = @"Data Source=localhost;Initial Catalog=DB;Integrated Security=True";



        static void Main(string[] args)
        {
            var usersToAdd = new UserEntity()
            { Name = "Sophia", Role = "STUDENT", CreatedAt = new DateTime(20210507), RemovedAt = null };
            var userList = new List<UserEntity>();
            userList.Add(usersToAdd);
            AddUsers(userList);


            var x = GetUsers();
            foreach (var item in x)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();

        }

        public static List<UserEntity> GetUsers()
        {
        //    string connectionString = @"Data Source=LAPTOP-CNL6SERI;Initial Catalog=UserEntity;Integrated Security=True";

            using (DataContext dataContext = new DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();

                IQueryable<UserEntity> query = users.Where(x => x.RemovedAt == null)
                                                    .Select(x => x);
                return query.ToList();
            }
        }

        public static void AddUsers(List<UserEntity> usersToAdd)
        {
                using (DataContext dataContext = new DataContext(connectionString))
            {
                UserEntity user = new UserEntity() 
                {Name ="Sophia", Role="STUDENT", CreatedAt= DateTime.Now, RemovedAt = null};
 
                dataContext.GetTable<UserEntity>().InsertOnSubmit(user);
                dataContext.SubmitChanges();                
            }
        }
    }
}
