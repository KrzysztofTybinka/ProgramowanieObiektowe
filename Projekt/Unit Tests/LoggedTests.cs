using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Projekt.Tests
{
    [TestClass]
    public class LoggedTests
    {
        [TestMethod]
        public void Login_Returns_True_If_Login_And_Password_Correct()
        {
            string login = "test123";
            string password = "Test123!";
            Assert.AreEqual(LoggedGuest.Login(login, password), true);
        }

        [TestMethod]
        public void Login_Returns_False_If_Login_Only_Is_Correct()
        {
            string login = "test123";
            string password = "Test123!#";
            Assert.AreEqual(LoggedGuest.Login(login, password), false);
        }

        [TestMethod]
        public void Login_Returns_False_If_Login_Is_Incorrect()
        {
            string login = "test1235";
            string password = "Test123!";
            Assert.AreEqual(LoggedGuest.Login(login, password), false);
        }

        [TestMethod]
        public void Logout_User_Sets_User_Property_To_Null()
        {
            string login = "test123";
            string password = "Test123!";
            LoggedGuest.Login(login, password);
            Assert.AreEqual(LoggedGuest.Guest.Name, "Test");
            LoggedGuest.Logout();
            Assert.AreEqual(LoggedGuest.Guest, null);
        }

    }
}
