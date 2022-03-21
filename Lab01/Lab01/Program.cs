using System;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj licznik i mianownik pierwszego ułamka");
            var input = Console.ReadLine().Split(" ");
            int licznik = Convert.ToInt32(input[0]);
            int mianownik = Convert.ToInt32(input[1]);

            var a = new Ulamek(licznik, mianownik);

            Console.WriteLine("Podaj licznik i mianownik drugiego ułamka");
            var input2 = Console.ReadLine().Split(" ");
            int licznik2 = Convert.ToInt32(input[0]);
            int mianownik2 = Convert.ToInt32(input[1]);

            var b = new Ulamek(licznik2, mianownik2);

            Console.WriteLine("Podaj typ operacji który chciałbyś wykonać na ułamkach: +, -, *, /");

            char operacja = Convert.ToChar(Console.ReadLine());

            if (operacja == '+')
                Console.WriteLine($"SUma ułamków wynosi {a + b}");
            if (operacja == '-')
                Console.WriteLine($"Różnica ułamków wynosi {a - b}");
            if (operacja == '*')
                Console.WriteLine($"Iloczyn ułamków wynosi {a * b}");
            if (operacja == '/')
                Console.WriteLine($"Iloraz ułamków wynosi {a / b}");
        }
    }
}
