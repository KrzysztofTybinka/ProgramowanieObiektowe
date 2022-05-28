using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media;

namespace Projekt.Test
{
    [TestClass]
    public class RegistervalidationTests
    {
        [TestMethod]
        public void PasswordStrength_Passwords_Are_Weak()
        {
            string[] passwords = { "abcd", "Abcd", "Ab123", "Abc12#", "asiydhgas",
                "Aasdnajuds", "123123123", "12839^^%*", "asdjas1231", "pasdnj23&*^"};

            for (int i = 0; i < passwords.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.PasswordStrength(passwords[i]), ("S³abe has³o", Brushes.Red));
            }
            
        }

        [TestMethod]
        public void PasswordStrength_Passwords_Are_Medium()
        {
            string[] passwords = { "Abcdef12", "1123SDFS"};

            for (int i = 0; i < passwords.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.PasswordStrength(passwords[i]), ("Œrednie has³o", Brushes.GreenYellow));
            }
        }

        [TestMethod]
        public void PasswordStrength_Passwords_Are_Strong()
        {
            string[] passwords = { "Abcdef12#", "1123SDFS^" };

            for (int i = 0; i < passwords.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.PasswordStrength(passwords[i]), ("Silne has³o", Brushes.Green));
            }
        }

        [TestMethod]
        public void PasswordStrength_Password_Is_Empty()
        {
            string password = "";
            Assert.AreEqual(RegisterValidation.PasswordStrength(password).Item1, "" );
        }

        [TestMethod]
        public void nameCheck_Name_Is_In_Proper_Format()
        {
            string[] names = { "Jacob", "JoSh", "jOSHUA", "KATIE", "annie" };

            for (int i = 0; i < names.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.NameCheck(ref names[i], "imie", out string info), true);
            }
        }

        [TestMethod]
        public void NameCheck_Name_Is_Not_In_Proper_Format()
        {
            string[] names = { "Jacob1", "12", "jOSHUA#!", "^&", "ssssssssssssssssssssssssssssssssssssssssssssssssssssssssss" };

            for (int i = 0; i < names.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.NameCheck(ref names[i], "imie", out string info), false);
            }
        }

        [TestMethod]
        public void LoginCheck_Login_Is_In_Proper_Format()
        {
            string[] logins = { "Jacob1", "12", "jOSHUA13", "1241" };

            for (int i = 0; i < logins.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.LoginCheck(logins[i], out string info), true);
            }
        }

        [TestMethod]
        public void LoginCheck_Login_Is_Not_In_Proper_Format()
        {
            string[] logins = { "Jacob1111111111111111111111111111111111111111111", "12#", "jOSHUA13!" };

            for (int i = 0; i < logins.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.LoginCheck(logins[i], out string info), false);
            }
        }

        [TestMethod]
        public void LoginCheck_Login_Is_Empty()
        {
            string login = "";
            Assert.AreEqual(RegisterValidation.LoginCheck(login, out string info), false);
            Assert.AreEqual(info, "Podaj login");
        }

        [TestMethod]
        public void EmailCheck_Email_Is_Not_In_Proper_Format()
        {
            string[] emails = {"asda@as@as.pl", "asd asd@op.pl", "asd@as%d.asd.pl", "asdasd", "asdads!asd.pl",
            "@.pl", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@aaaaaaaaaa.pl"};

            for (int i = 0; i < emails.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.EmailCheck(emails[i], out string info), false);
            }

        }

        [TestMethod]
        public void EmailCheck_Email_Is_Empty()
        {
            string email = "";
            Assert.AreEqual(RegisterValidation.EmailCheck(email, out string info), false);
            Assert.AreEqual(info, "Podaj adres email");
        }

        [TestMethod]
        public void PasswordCheck_Password_Is_Empty()
        {
            string password1 = "";
            string password2 = "";
            Assert.AreEqual(RegisterValidation.PasswordCheck(password1, password2, "Silne has³o", out string info), false);
            Assert.AreEqual(info, "WprowadŸ has³o");
        }

        [TestMethod]
        public void PasswordCheck_Passwords_Are_Not_Equal()
        {
            string[] passwords = {"ashd1", "aAdas@3asd"};
            string[] repPasswords = { "ashd12", "asdasdww" };

            for (int i = 0; i < passwords.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.PasswordCheck(passwords[i], repPasswords[i], "Silne has³o", out string info), false);
                Assert.AreEqual(info, "Has³a niezgodne");
            }
        }

        [TestMethod]
        public void PasswordCheck_Passwords_Are_Too_Weak()
        {
            string[] passwords = { "ashd1", "aAdas@3asd" };
            string[] repPasswords = { "ashd1", "aAdas@3asd" };

            for (int i = 0; i < passwords.Length; i++)
            {
                Assert.AreEqual(RegisterValidation.PasswordCheck(passwords[i], repPasswords[i], "S³abe has³o", out string info), false);
                Assert.AreEqual(info, "Has³o zbyt s³abe");
            }
        }

        [TestMethod]
        public void PasswordCheck_Password_Is_Too_Long()
        {
            string password1 = "sssssssssssssssssssssssssssssss";
            string password2 = "sssssssssssssssssssssssssssssss";
            Assert.AreEqual(RegisterValidation.PasswordCheck(password1, password2, "Silne has³o", out string info), false);
            Assert.AreEqual(info, "Has³o zbyt d³ugie");
        }

        [TestMethod]
        public void PasswordCheck_Password_Is_In_Proper_Format()
        {
            string password1 = "Abcd123$";
            string password2 = "Abcd123$";
            Assert.AreEqual(RegisterValidation.PasswordCheck(password1, password2, "Silne has³o", out string info), true);
            Assert.AreEqual(info, "");
        }
    }
}
