using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Async
{
    internal class Program
    {
        static HashSet<int> set = new HashSet<int>();
        static bool timer = true;

        static async Task Main(string[] args)
        {
            await CountPrimes();
            Console.Write(set.Count + " prime numbers found");
            Console.ReadLine();
        }

        static async Task CountPrimes()
        {
            Stopwatch s = Stopwatch.StartNew();

            int number = 2;
            while (s.ElapsedMilliseconds < 10000)
            {
                Task<Tuple<bool, int>> p1 = Task.Run(() => IsPrime(number));
                number++;
                Task<Tuple<bool, int>> p2 = Task.Run(() => IsPrime2(number));
                number++;
                Task<Tuple<bool, int>> p3 = Task.Run(() => IsPrime3(number));
                number++;
                Task<Tuple<bool, int>> p4 = Task.Run(() => IsPrime4(number));
                number++;

                var prime1 = await p1;
                if (prime1.Item1)
                    set.Add(prime1.Item2);
                var prime2 = await p2;
                if (prime2.Item1)
                    set.Add(prime2.Item2);
                var prime3 = await p3;
                if (prime3.Item1)
                    set.Add(prime3.Item2);
                var prime4 = await p4;
                if (prime4.Item1)
                    set.Add(prime4.Item2);
            }
        }

        static Tuple<bool, int> IsPrime(int number)
        {
            int limit = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= limit; i++)
            {
                if (number % i == 0)
                    return Tuple.Create(false, 0);

            }
            return Tuple.Create(true, number);
        }

        static Tuple<bool, int> IsPrime2(int number)
        {
            int limit = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= limit; i++)
            {
                if (number % i == 0)
                    return Tuple.Create(false, 0);

            }
            return Tuple.Create(true, number);
        }

        static Tuple<bool, int> IsPrime3(int number)
        {
            int limit = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= limit; i++)
            {
                if (number % i == 0)
                    return Tuple.Create(false, 0);

            }
            return Tuple.Create(true, number);
        }

        static Tuple<bool, int> IsPrime4(int number)
        {
            int limit = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= limit; i++)
            {
                if (number % i == 0)
                    return Tuple.Create(false, 0);

            }
            return Tuple.Create(true, number);
        }


    }
}
