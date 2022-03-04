using System;
using System.Linq;
using System.Collections.Generic;

namespace PokemonDontGo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> listOfDistances = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> removedElements = new List<int>();

            while (listOfDistances.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < listOfDistances.Count)
                {
                    int distance = listOfDistances[index];
                    removedElements.Add(distance);
                    listOfDistances.RemoveAt(index);
                    IncreaseAndDecreaseAllElements(listOfDistances, distance);
                }

                else if (index < 0)
                {
                    int firstElement = listOfDistances[0];
                    removedElements.Add(firstElement);
                    listOfDistances[0] = listOfDistances[listOfDistances.Count - 1];
                    IncreaseAndDecreaseAllElements(listOfDistances, firstElement);
                }

                else if (index >= listOfDistances.Count)
                {
                    int firstElement = listOfDistances[0];
                    int lastElement = listOfDistances[listOfDistances.Count - 1];
                    removedElements.Add(lastElement);
                    listOfDistances[listOfDistances.Count - 1] = firstElement;
                    IncreaseAndDecreaseAllElements(listOfDistances, lastElement);
                }
            }

            Console.WriteLine(removedElements.Sum());
        }
        private static void IncreaseAndDecreaseAllElements(List<int> listOfDistances, int distance)
        {
            for (int i = 0; i <= listOfDistances.Count - 1; i++)
            {
                if (listOfDistances[i] <= distance)
                {
                    listOfDistances[i] = listOfDistances[i] + distance;
                }
                else if (listOfDistances[i] > distance)
                {
                    listOfDistances[i] = listOfDistances[i] - distance;
                }
            }
        }
    }
}


