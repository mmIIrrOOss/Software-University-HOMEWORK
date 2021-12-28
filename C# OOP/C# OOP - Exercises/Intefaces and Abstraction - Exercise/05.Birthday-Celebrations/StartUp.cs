namespace _05.Birthday_Celebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StratUp
    {
        public static void Main(string[] args)
        {
            List<IBIrthdate> lists = new List<IBIrthdate>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] items = command.Split();
                string itemName = items[0];
                if (itemName == "Citizen")
                {
                    string name = items[1];
                    int age = int.Parse(items[2]);
                    string id = items[3];
                    string birthdate = items[4];
                    Citizens citizen = new Citizens(name, age, id, birthdate);
                    lists.Add(citizen);
                }
                else if (itemName == "Robot")
                {
                    continue;
                    string model = items[1];
                    string id = items[2];
                    Robots robot = new Robots(model, id);
                }
                else if (itemName == "Pet")
                {
                    string name = items[1];
                    string birthdate = items[2];
                    Pet pet = new Pet(name, birthdate);
                    lists.Add(pet);
                }
            }
            string yearCompareToCollectionBirthdate = Console.ReadLine();
            int count = 0;
            List<IBIrthdate> result = lists
                 .Where(x => x.Birthdate.EndsWith(yearCompareToCollectionBirthdate))
                 .ToList();
            if (result.Count > 0)
            {
                result
               .ToList()
               .ForEach(x => Console.WriteLine(x.Birthdate));
            }
        }
    }
}
