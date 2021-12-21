
namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            try
            {
                var lines = int.Parse(Console.ReadLine());
                var persons = new List<Person>();
                for (int i = 0; i < lines; i++)
                {
                    var items = Console.ReadLine().Split();
                    var name = items[0];
                    var lastName = items[1];
                    var age = int.Parse(items[2]);
                    var salary = decimal.Parse(items[3]);
                    var person = new Person(name, lastName, age, salary);
                    persons.Add(person);
                }
                var percentage = decimal.Parse(Console.ReadLine());
                persons.ForEach(p => p.IncreaseSalary(percentage));
                persons.ForEach(x => Console.WriteLine(x));
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }
    }
}
