namespace _01.Singleton
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SingleDataContainer : ISingleContainer
    {
        private Dictionary<string, int> capitals;

        private static SingleDataContainer instance = new SingleDataContainer();

        public static SingleDataContainer Instance => instance;

        public SingleDataContainer()
        {
            this.capitals = new Dictionary<string, int>();
            Console.WriteLine("Initializing singleton object");
            var elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i++)
            {
                this.capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }


        public int GetPopulation(string name)
        {
            return this.capitals[name];
        }
    }
}
