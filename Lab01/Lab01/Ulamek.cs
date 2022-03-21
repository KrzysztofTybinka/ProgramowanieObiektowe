using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    public class Ulamek : IEquatable<Ulamek>, IComparable<Ulamek>
    {
        private int licznik;
        private int mianownik;

        /// <summary>
        /// Gets licznik
        /// </summary>
        public int Licznik { get { return licznik; } }

        /// <summary>
        /// Gets mianownik
        /// </summary>
        public int Mianownik { get { return mianownik; } }

        /// <summary>
        /// Creates empty instance of class Ulamek
        /// </summary>
        public Ulamek()
        {

        }

        /// <summary>
        /// Creates instance of Ulamek class with given parameters
        /// </summary>
        /// <param name="licznik"></param>
        /// <param name="mianownik"></param>
        public Ulamek(int licznik, int mianownik)
        {
            this.licznik = licznik;
            this.mianownik = mianownik;
        }

        /// <summary>
        /// Creates Copy of Ulamek object
        /// </summary>
        /// <param name="ulamek"></param>
        public Ulamek(Ulamek ulamek)
        {
            this.licznik = ulamek.licznik;
            this.mianownik = ulamek.mianownik;
        }

        /// <summary>
        /// Sums two fractions
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Sum of two fractions</returns>
        public static Ulamek operator +(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.mianownik + b.licznik * a.mianownik, a.mianownik * b.mianownik);
        }

        /// <summary>
        /// Subtracts two given fractions
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>The difference between two fractions </returns>
        public static Ulamek operator -(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.mianownik - b.licznik * a.mianownik, a.mianownik * b.mianownik);
        }

        /// <summary>
        /// Multiplies two given fractions
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A product of two fractions</returns>
        public static Ulamek operator *(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.licznik, a.mianownik * b.mianownik);
        }

        /// <summary>
        /// Divides two given fractions
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Quotient of two fractions</returns>
        public static Ulamek operator /(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.mianownik, a.mianownik * b.licznik);
        }

        /// <summary>
        /// Compares two fractions
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True if fractions are equal, false if are not</returns>
        public static bool operator ==(Ulamek a, Ulamek b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares two fractions
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True if fractions are not equal, false if they are equal</returns>
        public static bool operator !=(Ulamek a, Ulamek b)
        {
            return !(a.Equals(b));
        }

        /// <summary>
        /// Checks if fraction a is bigger than fraction b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True if fraction a is bigger, otherwise false</returns>
        public static bool operator >(Ulamek a, Ulamek b)
        {
            if (((double)a.licznik / (double)a.mianownik) > ((double)b.licznik / (double)b.mianownik))
                return true;
            return false;
        }

        /// <summary>
        /// Checks if fraction a is smaller than fraction b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True if fraction a is smaller, otherwise false</returns>
        public static bool operator <(Ulamek a, Ulamek b)
        {
            double aValue = (double)a.licznik / (double)a.mianownik;
            double bValue = (double)b.licznik / (double)b.mianownik;

            if (aValue < bValue)
                return true;
            return false;
        }

        /// <summary>
        /// Checks if fraction a is bigger or equal to fraction b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True if fraction a is bigger or equal to fraction b, otherwise false</returns>
        public static bool operator <=(Ulamek a, Ulamek b)
        {
            if (((double)a.licznik / (double)a.mianownik) <= ((double)b.licznik / (double)b.mianownik))
                return true;
            return false;
        }

        /// <summary>
        /// Checks if fraction a is smaller or equal to fraction b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True if fraction a is smaller or equal to fraction b, otherwise false</returns>
        public static bool operator >=(Ulamek a, Ulamek b)
        {
            if (((double)a.licznik / (double)a.mianownik) >= ((double)b.licznik / (double)b.mianownik))
                return true;
            return false;
        }

        /// <summary>
        /// Rounds fraction to the integer
        /// </summary>
        /// <returns>The integer nearest fraction parameter</returns>
        public int Zaokraglij()
        {
            return Convert.ToInt32(Math.Round((decimal)licznik / (decimal)mianownik));
        }

        /// <summary>
        /// Raises number to a given power
        /// </summary>
        /// <param name="potega"></param>
        /// <returns>Fraction raised to a given power</returns>
        public Ulamek Potega(int potega)
        {
            int l = (int)Math.Pow(licznik, potega);
            int m = (int)Math.Pow(mianownik, potega);
            var u = new Ulamek(l, m);
            return u;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>String representation of a fraction</returns>
        public override string ToString()
        {
            return $"Licznik: {licznik}, Mianownik: {mianownik}";
        }

        /// <summary>
        /// Compares two given fractions
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>1 if comparator is bigger, -1 if comparator is lower, 0 if numbers are equal</returns>
        public int CompareTo(Ulamek obj)
        {
            double a = (double)this.licznik / this.mianownik;
            double b = (double)obj.licznik / obj.mianownik;

            if (a > b) return 1;
            if (a < b) return -1;
            return 0;
        }

        /// <summary>
        /// Checks if given fractions are equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True if they are equal, false if fractions are not equal</returns>
        public bool Equals(Ulamek other)
        {
            if ((double)this.licznik / this.mianownik == (double)other.licznik / other.mianownik)
                return true;
            return false;
        }
    }

}
