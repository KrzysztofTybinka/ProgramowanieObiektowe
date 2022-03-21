using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab01
{
    [TestClass]
    public class UnitTest1
    {
        public class Tests
        {
            [TestMethod]
            public void CreateObject_DefaultConstructor_2ArgsConstructor_CopyConstructor()
            {
                var twoArgs = new Ulamek(5, 12);
                var empty = new Ulamek();
                var copy = new Ulamek(twoArgs);
            }

            [TestMethod]
            public void ToStringReturnsString()
            {
                var x = new Ulamek(6, 8);

                string message = x.ToString();
                string expectesMsg = "Licznik: 6, Mianownik: 8";

                Assert.AreEqual(expectesMsg, message);
            }

            [TestMethod]
            public void Operators_Sum_Division_Multiplication_Substraction()
            {
                var ulamek1 = new Ulamek(3, 4);
                var ulamek2 = new Ulamek(5, 6);

                Ulamek wynikDodawania = ulamek1 + ulamek2;
                Ulamek wynikOdejmowania = ulamek1 - ulamek2;
                Ulamek wynikMnozenia = ulamek1 * ulamek2;
                Ulamek wynikDzielenia = ulamek1 / ulamek2;

                Assert.AreEqual(new Ulamek(38, 24), wynikDodawania);
                Assert.AreEqual(new Ulamek(-1, 12), wynikOdejmowania);
                Assert.AreEqual(new Ulamek(15, 24), wynikMnozenia);
                Assert.AreEqual(new Ulamek(18, 20), wynikDzielenia);
            }

            [TestMethod]
            public void Compare()
            {
                var a = new Ulamek(2, 8);
                var b = new Ulamek(4, 7);

                int value = a.CompareTo(b);

                Assert.AreEqual(-1, value);
            }

            [TestMethod]
            public void Equals()
            {
                var a = new Ulamek(2, 8);
                var b = new Ulamek(4, 7);

                bool value = a.Equals(b);

                Assert.AreEqual(false, value);
            }

            [TestMethod]
            public void TryGetLicznik_TryGetMianownik()
            {
                var a = new Ulamek(2, 6);

                Assert.AreEqual(2, a.Licznik);
                Assert.AreEqual(6, a.Mianownik);
            }

            [TestMethod]
            public void Zaokraglanie()
            {
                var a = new Ulamek(6, 5);

                int b = a.Zaokraglij();

                Assert.AreEqual(1, b);
            }

            [TestMethod]
            public void Potega()
            {
                var a = new Ulamek(2, 4);

                Ulamek b = a.Potega(3);

                Assert.AreEqual(new Ulamek(8, 64), b);
            }

            [TestMethod]
            public void ConsoleReadInputsAndSum_Subtract_Multiply_Divide()
            {

            }

            [TestMethod]
            public void CheckIsEqualOperator()
            {
                var a = new Ulamek(2, 3);
                var b = new Ulamek(2, 3);
                var c = new Ulamek(2, 8);

                bool res1 = a == b;
                bool res2 = a == c;

                Assert.AreEqual(true, res1);
                Assert.AreEqual(false, res2);
            }

            [TestMethod]
            public void CheckIsNotEqualOperator()
            {
                var a = new Ulamek(2, 3);
                var b = new Ulamek(2, 3);
                var c = new Ulamek(2, 8);

                bool res1 = a != b;
                bool res2 = a != c;

                Assert.AreEqual(false, res1);
                Assert.AreEqual(true, res2);
            }

            [TestMethod]
            public void CheckIsBiggerOperator()
            {
                var a = new Ulamek(2, 3);
                var b = new Ulamek(2, 3);
                var c = new Ulamek(2, 8);
                var d = new Ulamek(6, 7);

                bool res1 = a > b;
                bool res2 = a > c;
                bool res3 = a > d;

                Assert.AreEqual(false, res1);
                Assert.AreEqual(true, res2);
                Assert.AreEqual(false, res3);
            }

            [TestMethod]
            public void CheckIsSmallerOperator()
            {
                var a = new Ulamek(2, 3);
                var b = new Ulamek(2, 3);
                var c = new Ulamek(2, 8);
                var d = new Ulamek(6, 7);

                bool res1 = a < b;
                bool res2 = a < c;
                bool res3 = a < d;

                Assert.AreEqual(false, res1);
                Assert.AreEqual(false, res2);
                Assert.AreEqual(true, res3);
            }
            [TestMethod]
            public void CheckIsBiggerOrEqualOperator()
            {
                var a = new Ulamek(2, 3);
                var b = new Ulamek(2, 3);
                var c = new Ulamek(2, 8);
                var d = new Ulamek(6, 7);

                bool res1 = a >= b;
                bool res2 = a >= c;
                bool res3 = a >= d;

                Assert.AreEqual(true, res1);
                Assert.AreEqual(true, res2);
                Assert.AreEqual(false, res3);
            }
            [TestMethod]
            public void CheckIsSmallerOrEqualOperator()
            {
                var a = new Ulamek(2, 3);
                var b = new Ulamek(2, 3);
                var c = new Ulamek(2, 8);
                var d = new Ulamek(6, 7);

                bool res1 = a <= b;
                bool res2 = a <= c;
                bool res3 = a <= d;

                Assert.AreEqual(true, res1);
                Assert.AreEqual(false, res2);
                Assert.AreEqual(true, res3);
            }
        }
    }
}
