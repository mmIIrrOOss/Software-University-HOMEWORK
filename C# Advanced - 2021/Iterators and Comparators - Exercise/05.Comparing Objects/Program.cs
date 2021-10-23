
namespace _05.Comparing_Objects
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            const string Command = "END";
            string command;
            List<Person> people = new List<Person>();
            while ((command = Console.ReadLine()) != Command)
            {
                string[] commandArg = command.Split();
                string name = commandArg[0];
                int age = int.Parse(commandArg[1]);
                string town = commandArg[2];
                Person person = new Person(name, age, town);
                people.Add(person);
            }
            int n = int.Parse(Console.ReadLine());
            Person comparedPerson = people[n - 1];
            int somePersonCount = 0;
            foreach (var person in people)
            {
                if (person.CompareTo(comparedPerson) == 0)
                {
                    somePersonCount++;
                }
            }
            if (somePersonCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int notSomePersonCount = people.Count - somePersonCount;
                Console.WriteLine($"{somePersonCount} {notSomePersonCount} {people.Count}");
            }

        }
    }
}
