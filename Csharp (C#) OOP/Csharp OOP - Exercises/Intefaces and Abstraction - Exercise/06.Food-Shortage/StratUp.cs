namespace _06.Food_Shortage
{
    using _06.Food_Shortage.Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StratUp
    {
        public static void Main()
        {
            List<IBuyer> colection = new List<IBuyer>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] items = Console.ReadLine().Split();
                if (items.Length == 3)
                {
                    AddRebel(colection, items);
                }
                else if (items.Length == 4)
                {
                    AddCitizen(colection, items);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var buyer = colection.SingleOrDefault(x => x.Name == command);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
            Console.WriteLine(colection.Sum(x => x.Food));
        }

        private static void AddRebel(List<IBuyer> colection, string[] items)
        {
            string name = items[0];
            int age = int.Parse(items[1]);
            string group = items[2];
            Rebel rebel = new Rebel(name, age, group);
            colection.Add(rebel);
        }

        private static void AddCitizen(List<IBuyer> colection, string[] items)
        {
            string name = items[0];
            int age = int.Parse(items[1]);
            string id = items[2];
            string birthdate = items[3];
            Citizens citizens = new Citizens(name, age, id, birthdate);
            colection.Add(citizens);
        }
    }
}
