using System;
using System.Threading;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            //zad 1
            Console.WriteLine("zad 1");
            Console.WriteLine();
            ObservableList1<int> list1 = new ObservableList1<int>();

            list1.Added += (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Added event occured: value added = " + e.Value);
            };

            list1.Removed += (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Subtracted event occured: value removed = " + e.Value);
            };

            list1.Updated += (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Updated event occured: value changed = " + e.Value);
            };

            list1.Add(5);
            list1.Add(8);
            list1.Add(2);

            list1.RemoveAt(1);
            list1[1] = 12;

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            //zad 2
            Console.WriteLine("zad 2");
            Console.WriteLine();

            ObservableList2 list2 = new ObservableList2(delegate (int i)
            {
                Console.WriteLine("Adding value: " + i + "...");
            }
            , delegate (int i)
            {
                Console.WriteLine("Changing value at index: " + i + "...");
            }
            , delegate (int i)
            {
                Console.WriteLine("Removing value at index: " + i + "...");
            });
           
            list2.Add(5);
            list2.Add(8);
            list2.Add(2);

            list2.RemoveAt(1);
            list2[1] = 12;

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            //zad 3
            Console.WriteLine("zad 3");
            Console.WriteLine();

            ObservableList3<int> list3 = new ObservableList3<int>();

            list3.Add(5);
            list3.Add(8);
            list3.Add(2);

            list3.RemoveAt(1);
            list3[1] = 12;

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            //zad 4
            Console.WriteLine("zad 4");
            Console.WriteLine();
            ObservableList1Lambda<int> list1Lambda = new ObservableList1Lambda<int>();

            list1Lambda.Added += (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Added event occured: value added = " + e.Value);
            };

            list1Lambda.Removed += (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Subtracted event occured: value removed = " + e.Value);
            };

            list1Lambda.Updated += (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Updated event occured: value changed = " + e.Value);
            };

            list1Lambda.Add(5);
            list1Lambda.Add(8);
            list1Lambda.Add(2);

            list1Lambda.RemoveAt(1);
            list1Lambda[1] = 12;

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            //zad 5
            Console.WriteLine("zad 5");
            Console.WriteLine();

            ObservableList1<int> list5 = new ObservableList1<int>();

            list5.Added += (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Added event occured: value added = " + e.Value);
            };

            list5.Removed += (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Subtracted event occured: value removed = " + e.Value);
            };

            list5.Updated += (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Updated event occured: value changed = " + e.Value);
            };

            list5.Add(5);
            list5.Add(8);
            Console.Write("Current list values: ");
            for (int i = 0; i < list5.Length; i++)
            {
                Console.Write(list5[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine("Removing Add event...");

            list5.Added -= (object sender, ChangedEventArgs<int> e) =>
            {
                Console.WriteLine("Added event occured: value added = " + e.Value);
            };

            Console.WriteLine("Adding value to the list...");
            list5.Add(2);
            Console.Write("Current list values: ");
            for (int i = 0; i < list5.Length; i++)
            {
                Console.Write(list5[i]);
                Console.Write(" ");
            }

        }

    }


}
