using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
