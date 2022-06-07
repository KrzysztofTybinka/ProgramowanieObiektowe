using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Projekt.Test
{
    [TestClass]
    public class DatabaseConnectorTest
    {
        [TestMethod]
        public void ChangePassword_Changes_password()
        {
            string email = "test@test.com";
            string newPassword = "NewPassword123#";
            DatabaseConnector.ChangePassword(newPassword, email);
            Assert.AreEqual(DatabaseConnector.GuestByEmailOrLogin(email).Password, newPassword);
            DatabaseConnector.ChangePassword("Test123!", email);
        }

        [TestMethod]
        public void GuestByEmailOrLogin_Searches_Guest_By_Email_Returns_Guest()
        {
            string expectedLogin = "test123";
            string email = "test@test.com";
            var g = DatabaseConnector.GuestByEmailOrLogin(email);
            Assert.AreEqual(expectedLogin, g.Login);
        }

        [TestMethod]
        public void GuestByEmailOrLogin_Searches_Guest_By_Email_Returns_Null()
        {
            string expectedLogin = null;
            string email = "notindb@test.com";
            var g = DatabaseConnector.GuestByEmailOrLogin(email);
            Assert.AreEqual(expectedLogin, g);
        }

        [TestMethod]
        public void GuestByEmailOrLogin_Searches_Guest_By_Login_Returns_Guest()
        {
            string expectedEmail = "test@test.com";
            string login = "test123";
            var g = DatabaseConnector.GuestByEmailOrLogin(login);
            Assert.AreEqual(expectedEmail, g.Email);
        }

        [TestMethod]
        public void GuestByEmailOrLogin_Searches_Guest_By_Login_Returns_Null()
        {
            string expectedEmail = null;
            string login = "notindb12";
            var g = DatabaseConnector.GuestByEmailOrLogin(login);
            Assert.AreEqual(expectedEmail, g);
        }

        [TestMethod]
        public void InsertGuest_Inserts_New_Guest_Successfully()
        {
            Guests u = new Guests
            {
                Name = "TestName",
                Surname = "TestSurname",
                Login = "TestLogin",
                Email = "test@email.com",
                Password = "TestPass123$",
                IsAdmin = false
            };
            Assert.AreEqual(DatabaseConnector.InsertGuest(u), true);
            var g = DatabaseConnector.GuestByEmailOrLogin("TestLogin");
            Assert.AreEqual((u.Name, u.Email), (g.Name, g.Email));
            DatabaseConnector.RemoveGuestWithEmailOrLogin("TestLogin");
        }

        [TestMethod]
        public void InsertGuest_Inserts_New_Guest_Unsuccessfully()
        {
            Guests u = new Guests
            {
                Name = "TestName",
                Surname = "TestSurname",
                Login = "TestLogin",
                Email = "test@email.com",
                Password = "TestPass123$",
                IsAdmin = false
            };
            DatabaseConnector.InsertGuest(u);
            Assert.AreEqual(DatabaseConnector.InsertGuest(u), false);
            DatabaseConnector.RemoveGuestWithEmailOrLogin("TestLogin");
        }

        [TestMethod]
        public void IsInGuest_User_Is_In_Guests_With_Email()
        {
            string email = "test@test.com";
            Assert.AreEqual(DatabaseConnector.IsInGuests(email), true);
        }

        [TestMethod]
        public void IsInGuest_User_Is_In_Guests_With_Login()
        {
            string login = "test123";
            Assert.AreEqual(DatabaseConnector.IsInGuests(login), true);
        }

        [TestMethod]
        public void IsInGuest_User_Is_In_Guests_With_User()
        {
            var u = DatabaseConnector.GuestByEmailOrLogin("test123");
            Assert.AreEqual(DatabaseConnector.IsInGuests(u.Login), true);
        }

        [TestMethod]
        public void RemoveGuestWithEmailOrLogin_Guest_Removed()
        {
            Guests u = new Guests
            {
                Name = "TestName",
                Surname = "TestSurname",
                Login = "TestLogin",
                Email = "test@email.com",
                Password = "TestPass123$",
                IsAdmin = false
            };
            DatabaseConnector.InsertGuest(u);
            DatabaseConnector.RemoveGuestWithEmailOrLogin("test@email.com");
            Assert.AreEqual(DatabaseConnector.IsInGuests(u), false);
        }

        [TestMethod]
        public void SearchCategories_Returns_Array_With_Categories()
        {
            string toassert = "Boisko do koszykówki";
            var arr = DatabaseConnector.SearchCategories();
            Assert.AreEqual(arr[0], toassert);
        }

        [TestMethod]
        public void AddCategory_Returns_False_For_Null_Input()
        {
            bool b = DatabaseConnector.AddCategory(null);
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void AddCategory_Returns_False_For_Too_Long_Input()
        {
            bool b = DatabaseConnector.AddCategory("sssssssssssssssssssssssssssss");
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void AddCategory_Adds_Category()
        {
            string category = "testowa kategoria";
            bool b = DatabaseConnector.AddCategory(category);
            var arr = DatabaseConnector.SearchCategories();
            Assert.IsTrue(b);
            Assert.IsTrue(arr.Contains(category));
            DatabaseConnector.DeleteCategory(category);
        }

        [TestMethod]
        public void AddCategory_Returns_False_For_Inserting_Twice_Same_Category()
        {
            string category = "testowa kategoria";
            Assert.IsTrue(DatabaseConnector.AddCategory(category));
            Assert.IsFalse(DatabaseConnector.AddCategory(category));
            DatabaseConnector.DeleteCategory(category);
        }

        [TestMethod]
        public void DeleteCategory_Deletes_Category()
        {
            string category = "testowa kategoria";
            Assert.IsTrue(DatabaseConnector.AddCategory(category));
            DatabaseConnector.DeleteCategory(category);
            var arr = DatabaseConnector.SearchCategories();
            Assert.IsFalse(arr.Contains(category));
        }

        [TestMethod]
        public void SearchFields_Returns_Array_With_Fields()
        {
            var arr = DatabaseConnector.SearchFields();
            Assert.IsTrue(arr.Contains("Id: 3\nNazwa: Koszykówka #1\nKategoria: Boisko do koszykówki\n"));
        }

        [TestMethod]
        public void AddField_Returns_False_For_Null_Input()
        {
            bool b = DatabaseConnector.AddField(null);
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void AddField_Returns_False_For_Too_Long_Input()
        {
            bool b = DatabaseConnector.AddField(new Fields { Name = "sssssssssssssssssssssssssssssss", Category = "Boisko do koszykówki"});
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void AddField_Returns_False_If_Category_Doesnt_Exist()
        {
            bool b = DatabaseConnector.AddField(new Fields { Name = "test", Category = "abcd" });
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void AddField_Returns_False_For_Inserting_Twice_Same_Field()
        {
            Assert.IsFalse(DatabaseConnector.AddField(new Fields { Name = "Koszykówka #1", Category = "Boisko do koszykówki" }));
        }

        [TestMethod]
        public void DeleteField_Deletes_Field()
        {
            DatabaseConnector.AddField(new Fields { Name = "test", Category = "Boisko do koszykówki"});
            var f = DatabaseConnector.SearchFields();
            int id = 0;
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i].Contains("test"))
                {
                    var arr = f[i].Split('\n', ' ');
                    id = Convert.ToInt32(arr[1]);
                }
            }
            Assert.IsTrue(DatabaseConnector.DeleteField(id));
        }

        [TestMethod]
        public void AddToReserve_Returns_False_For_Null_Input()
        {
            bool b = DatabaseConnector.AddToReserve(null);
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void AddToReserve_Returns_False_If_Category_Doesnt_Exist()
        {
            bool b = DatabaseConnector.AddToReserve(new ToReserve { Field = 999, Date = new DateTime(2022, 05, 07, 00, 00, 00) });
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void AddToReserve_Returns_False_For_Inserting_Twice_Same_ToReserve()
        {
            DatabaseConnector.AddToReserve(new ToReserve { Field = 3, Date = new DateTime(2022, 05, 07, 00, 00, 00) });
            Assert.IsFalse(DatabaseConnector.AddToReserve(new ToReserve { Field = 3, Date = new DateTime(2022, 05, 07, 00,00,00)}));
        }

        [TestMethod]
        public void DeleteToReserve_Deletes_ToReserve()
        {
            DatabaseConnector.AddToReserve(new ToReserve { Field = 3, Date = new DateTime(2022, 09, 12, 00, 00, 00) });
            var f = DatabaseConnector.SearchToReserve();
            int id = 0;
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i].Contains("12.09.2022"))
                {
                    var arr = f[i].Split('\n', ' ');
                    id = Convert.ToInt32(arr[1]);
                }
            }
            Assert.IsTrue(DatabaseConnector.DeleteToReserve(id));
        }

        [TestMethod]
        public void UpdateToReserve_Deletes_Expired_ToReserve_Fields()
        {
            var s = new ToReserve { Date = new DateTime(2022, 05, 05, 00, 00, 00, 00), Field = 3 };
            DatabaseConnector.AddToReserve(s);
            DatabaseConnector.UpdateToReserve();
            var arr = DatabaseConnector.SearchToReserve();
            Assert.IsFalse(arr.Contains("Koszykówka #1\nData: 05.05.2022\n"));

        }

        [TestMethod]
        public void SearchGuests_Returns_Guest_Array()
        {
            var arr = DatabaseConnector.SearchGuests();
            foreach (var item in arr)
            {
                if (item.Contains("Test"))
                    Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void GuestList_Returns_Guest_List()
        {
            var g = DatabaseConnector.GuestsList();
            foreach (var item in g)
            {
                if (item.Name.Equals("Test"))
                    Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void SearchReservations_Returns_Reservations_Array()
        {
            var arr = DatabaseConnector.SearchReservations();
            foreach (var item in arr)
            {
                if (item.Contains("Id osoby"))
                    Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void DeleteReservation_returns_False_For_Not_Existing_Reservation()
        {
            Assert.IsFalse(DatabaseConnector.DeleteReservation(5, 9));
        }

        [TestMethod]
        public void AddReservation_Returns_False_For_Invalid_Data()
        {
            Assert.IsFalse(DatabaseConnector.AddReservation(555, 9999));
        }

    }
}
