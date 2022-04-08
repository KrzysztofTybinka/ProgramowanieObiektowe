using System;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            var chuj = new DynamicArray<string?>();

            chuj[20] = "cippa";

            foreach (var item in chuj)
            {
                Console.WriteLine(item);
            }
        }
    }
}
