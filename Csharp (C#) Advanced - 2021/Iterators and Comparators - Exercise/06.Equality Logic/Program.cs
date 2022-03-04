
namespace _06.Equality_Logic
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            HashSet<Person> hasPeople = new HashSet<Person>();
            SortedSet<Person> sortPeople = new SortedSet<Person>();
            for (int i = 0; i < lines; i++)
            {
                string[] agrss = Console.ReadLine().Split();
                string name = agrss[0];
                int age = int.Parse(agrss[1]);
                Person person = new Person(name, age);
                hasPeople.Add(person);
                sortPeople.Add(person);
            }
            Console.WriteLine(hasPeople.Count);
            Console.WriteLine(sortPeople.Count);
        }
    }
}
