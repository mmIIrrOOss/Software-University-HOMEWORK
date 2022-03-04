

namespace Implementing_Stack_and_Queue
{
    using System;
    class Program
    {
        static void Main()
        {
            CustomList customList = new CustomList();
            Console.WriteLine("---Adding elements on my CustomList");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Adding... - {0}", i);
                customList.Add(i);
            }

            for (int i = 0; i < customList.Count; i++)
            {
                Console.WriteLine("Print ingredients my elements at my CustomList... - {0}", customList[i]);
            }


            Console.WriteLine("Insert this element and indexes.");
            Console.WriteLine("This moment count of my List {0}", customList.Count);
            customList.Insert(5, 9);
            Console.WriteLine($"This moment Count of my List ---{customList.Count}");

            Console.WriteLine("Contans element on my List {0}", customList.Contains(9));
            Console.WriteLine("Contans element on my List {0}", customList.Contains(100));

            customList.Add(8);
            int firstIndex = 0;
            int secondIndex = customList.Count - 1;
            Console.WriteLine("First swap element - {0}", customList[firstIndex]);
            Console.WriteLine("Second swap element - {0}", customList[secondIndex]);
            customList.Swap(firstIndex, secondIndex);
            Console.WriteLine("Swaping elemnts..........");
            Console.WriteLine($"Swaping succesfull! View Change down");
            Console.WriteLine($"{customList[firstIndex]}");
            Console.WriteLine($"{customList[secondIndex]}");
            for (int i = 0; i < customList.Count - 1; i++)
            {
                Console.WriteLine(customList[i]);
            }

            Console.WriteLine($"Removed this element - {customList[0]}");
            customList.RemoveAt(customList[0]);

            Console.WriteLine("END!");
        }
    }
}
