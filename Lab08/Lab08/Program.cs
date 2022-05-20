using System;
using System.Threading;

public class Program
{
    static void Main(string[] args)
    {
        Object locker = new Object();

        int couter = 0;

        // In the below, operation `couter = couter + 1` is not atomic.
        //
        // It requires:
        //   1. read `count` value from memory (RAM)
        //   2. add 1 to `count` value in procesor (CPU)
        //   3. write `count` value into memory (RAM)

        Thread t1 = new Thread(() =>
        {
            for (int i = 0; i < 1000; ++i)
            {

                lock (locker) // remove this line and check output to see effect
                {
                    couter = couter + 1;
                }
            }
        });

        Thread t2 = new Thread(() =>
        {
            for (int i = 0; i < 1000; ++i)
            {

                lock (locker) // remove this line and check output to see effect
                {
                    couter = couter + 1;
                }
            }
        });

        t1.Start();
        //Thread.Sleep(500);
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("couter=" + couter);  // 2000
    }
}