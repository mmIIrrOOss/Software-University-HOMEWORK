namespace _04.Border_Control
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<IIdentifiable> lists = new List<IIdentifiable>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] items = command.Split();
                if (items.Length == 3)
                {
                    string name = items[0];
                    int age = int.Parse(items[1]);
                    string id = items[2];
                    Citizen citizen = new Citizen(name, age, id);
                    lists.Add(citizen);
                }
                else if (items.Length == 2)
                {
                    string model = items[0];
                    string id = items[1];
                    Robot robot = new Robot(model, id);
                    lists.Add(robot);
                }
            }
            string numberCompareToId = Console.ReadLine();
            foreach (var identifiable in lists)
            {
                string id = identifiable.Id;
                string substringId = identifiable.Id.Substring(id.Length - numberCompareToId.Length);
                if (!(substringId == numberCompareToId))
                {
                    continue;
                }
                Console.WriteLine(identifiable.Id);
            }
        }
    }
}
