using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab08
{
    public class Threads
    {
        static HashSet<int> set = new HashSet<int>();
        static bool timer = true;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                int number = 0;
                while (timer)
                {
                    if (IsPrime(number))
                    {
                        lock (set)
                        {
                            set.Add(number);
                        }
                    }
                    number += 4;
                }
            });

            Thread t2 = new Thread(() =>
            {
                int number = 1;
                while (timer)
                {
                    if (IsPrime(number))
                    {
                        lock (set)
                        {
                            set.Add(number);
                        }
                    }
                    number += 4;
                }

            });

            Thread t3 = new Thread(() =>
            {
                int number = 2;
                while (timer)
                {
                    if (IsPrime(number))
                    {
                        lock (set)
                        {
                            set.Add(number);
                        }
                    }
                    number += 4;
                }

            });

            Thread t4 = new Thread(() =>
            {
                int number = 3;
                while (timer)
                {
                    if (IsPrime(number))
                    {
                        lock (set)
                        {
                            set.Add(number);
                        }
                    }
                    number += 4;
                }

            });
            
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t4.Join(10000);
            timer = false;
            Console.Write(set.Count + " prime numbers found");
            Console.ReadLine();



        }

        static bool IsPrime(int number)
        {
            int limit = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= limit; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

    }
}





